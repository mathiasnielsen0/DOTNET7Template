using Microsoft.AspNetCore.Mvc;

namespace Website.Infrastructure;

public class BaseController : Controller
{
    protected IActionResult ErrorView()
    {
        return View("Error");
    }
}