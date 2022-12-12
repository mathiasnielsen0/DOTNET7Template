using Core.Repositories;
using Website;

namespace DatabaseAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly Dotnet7Context _database;

    public UserRepository(Dotnet7Context database)
    {
        _database = database;
    }
    
    public void CreateUser(string email)
    {
        
    }
}