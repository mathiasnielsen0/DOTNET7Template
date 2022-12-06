using System.Security.Claims;
using Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Website.Infrastructure;
using Website.Models;

namespace Website.Controllers;

[Authorize]
public class AccountController : BaseController
{
    private readonly AuthenticationHelper _authenticationHelper;

    public AccountController(AuthenticationHelper authenticationHelper)
    {
        _authenticationHelper = authenticationHelper;
    }

    public async Task<IActionResult> Register()
    {
        var vm = new AccountRegisterViewModel();
        return View(vm);
    }

    public async Task<IActionResult> Register(AccountRegisterViewModel vm)
    {

        return RedirectToAction("Login");
    }

    // Something failed. Redisplay the
    
    public async Task<IActionResult> Login()
    {

        return View();
    }
    
    public async Task<IActionResult> Login()
    {
        if (ModelState.IsValid)
        {
            // Use Input.Email and Input.Password to authenticate the user
            // with your custom authentication logic.
            //
            // For demonstration purposes, the sample validates the user
            // on the email address maria.rodriguez@contoso.com with 
            // any password that passes model validation.

            var user = await _authenticationHelper.AuthenticateUser(Input.Email, Input.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return ErrorView();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("FullName", user.FullName),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            // _logger.LogInformation("User {Email} logged in at {Time}.",
            //     user.Email, DateTime.UtcNow);

        }

    }
    
    public async Task<IActionResult> SignOut()
    {
        // Clear the existing external cookie
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Home");
    }
    
}