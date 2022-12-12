using Core.Models.User;

namespace Core.Interfaces;

public interface IAuthenticationHelper
{
    Task<UserModel?> AuthenticateUser(string email, string password);
}