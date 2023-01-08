using Core.Models.User;

namespace Core.Interfaces.Queries;

public interface IUserQueryFactory
{
    Task<UserModel?> Get(int id);
    Task<UserModel?> GetByEmail(string email);
}