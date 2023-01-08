using Core.Models.User;

namespace Core.Interfaces.Repositories;

public interface IUserRepository
{
    void CreateUser(string email, string password);
}