using EasyAuthMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EasyAuthMVC.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        ViewData["IsAuthenticated"] = User.Identity.IsAuthenticated;
        ViewData["Name"] = User.Identity.Name;

        IEnumerable<KeyValuePair<string, string>> headers = Request.Headers.Select(x => new KeyValuePair<string, string>(x.Key, x.Value));
        return View(headers);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
