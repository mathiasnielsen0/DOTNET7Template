using Core.Models.User;

namespace Core.Interfaces;

public interface IAuthenticationHelper
{
    /// <summary>
    /// Returns null if user was not found or password was incorrect
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<UserModel?> AuthenticateUser(string email, string password);
}