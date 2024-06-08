using System.Diagnostics;
using Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TestLocalization.Models;
namespace TestLocalization.Controllers;

[Route("api/[controller]")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStringLocalizer<SharedResource> _sharedResourceLocalizer;
    public HomeController(
        ILogger<HomeController> logger,
    IStringLocalizer<SharedResource> sharedResourceLocalizer
        )
    {
        _logger = logger;
        _sharedResourceLocalizer = sharedResourceLocalizer;
    }

    public IActionResult Index()
    {
        return View();
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

    [AllowAnonymous]
    [HttpGet("TestLocalize")]
    public IActionResult TestLocalize()
    {
        var localizedTexts = _sharedResourceLocalizer.GetAllStrings();
        Console.WriteLine($"IS ResourceNotFound:::{localizedTexts.Count() > 0}");
        return Ok(new { data = "SS", currentDate = DateTime.UtcNow });
    }


}
