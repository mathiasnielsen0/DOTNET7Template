using Core.Interfaces.Repositories;
using DatabaseAccess.Data;

namespace DatabaseAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbContextConnection _database;
    public UserRepository(DbContextConnection database)

    {
        _database = database;
    }
    
    public void CreateUser(string email, string password)
    {
        
    }
}