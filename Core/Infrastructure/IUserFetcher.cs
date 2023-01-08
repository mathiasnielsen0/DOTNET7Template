namespace DomainModel.Infrastructure;

public interface IUserFetcher
{
    int GetCurrentUser();
    string GetCurrentUserName();
}