using Core.Interfaces;
using Core.Interfaces.Queries;
using Core.Models.User;

namespace Authentication;

public class AuthenticationHelper : IAuthenticationHelper
{
    private readonly IUserQueryFactory _userQueryFactory;
    private readonly IPasswordUtilities _passwordUtilities;

    public AuthenticationHelper(IUserQueryFactory userQueryFactory, IPasswordUtilities passwordUtilities)
    {
        _userQueryFactory = userQueryFactory;
        _passwordUtilities = passwordUtilities;
    }
    
    public async Task<UserModel?> AuthenticateUser(string email, string password)
    {
        var user = await _userQueryFactory.GetByEmail(email);

        if (user == null)
            return null;

        var success = _passwordUtilities.ValidatePassword(password, user.PasswordHash, user.Salt);

        if (!success)
            return null;

        return user;
    }
}