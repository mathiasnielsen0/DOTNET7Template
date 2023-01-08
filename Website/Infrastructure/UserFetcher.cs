using Core.Models.User;
using DomainModel.Infrastructure;

namespace Website.Infrastructure;

public class UserFetcher : IUserFetcher
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserFetcher(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public int GetCurrentUser()
    {
        if (_httpContextAccessor.HttpContext == null) return 0;

        return (int.TryParse(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == Claims.UserID).Value, out var id))
            ? id
            : 0;
    }

    public string GetCurrentUserName()
    {
        if (_httpContextAccessor.HttpContext == null) return "System";

        return _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == Claims.UserName).Value;
    }
}