using Core.Interfaces.Queries;
using Core.Models.User;
using DatabaseAccess.Data;
using DomainModel.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Queries;

public class UserQueryFactory : IUserQueryFactory
{
    private readonly ReadContext _database;
    private readonly IMapper _mapper;

    public UserQueryFactory(ReadContext database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }
    
    public async Task<UserModel?> Get(int id)
    {
        return await _database.Users
            .Where(x => x.Id == id)
            .ProjectTo<UserModel>(_mapper)
            .SingleOrDefaultAsync();
    }

    public async Task<UserModel?> GetByEmail(string email)
    {
        return await _database.Users
            .Where(x => x.Email == email)
            .ProjectTo<UserModel>(_mapper)
            .SingleOrDefaultAsync();
    }
}