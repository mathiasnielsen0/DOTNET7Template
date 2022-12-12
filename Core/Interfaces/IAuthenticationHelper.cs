using Core.Models;

namespace Core.Interfaces;

public interface IAuthenticationHelper
{
    Task<UserModel?> AuthenticateUser(string email, string password);
}