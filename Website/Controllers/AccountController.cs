using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Website.Infrastructure;

namespace Website.Controllers;

[Authorize]
public class AccountController : BaseController
{
    public AccountController()
    {
        
    }

    public async Task<IActionResult> Register()
    {

        return View();
    }
    
    public async Task<IActionResult> Login()
    {

        return View();
    }
    
    public async Task<IActionResult> SignOut()
    {

        return View();
    }
    
}