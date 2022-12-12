using Core.Interfaces;

public class UserControllerActionHandler
{
    private readonly IAuthenticationHelper _authenticationHelper;

    public UserControllerActionHandler(IAuthenticationHelper authenticationHelper)
    {
        _authenticationHelper = authenticationHelper;
    }
}