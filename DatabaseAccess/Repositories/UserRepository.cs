using Core.Interfaces.Repositories;
using DatabaseAccess.Data;

namespace DatabaseAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WriteContext _database;
    public UserRepository(WriteContext database)

    {
        _database = database;
    }
    
    public void CreateUser(string email, string password)
    {
        
    }
}