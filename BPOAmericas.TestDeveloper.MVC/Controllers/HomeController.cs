using BPOAmericas.TestDeveloper.MVC.Models;
using BPOAmericas.TestDeveloper.MVC.Models.Login;
using BPOAmericas.TestDeveloper.MVC.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace BPOAmericas.TestDeveloper.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthService _authApiService;

        public HomeController(ILogger<HomeController> logger, AuthService authService)
        {
            _logger = logger;
            _authApiService = authService;
        }

        public IActionResult Index()
        {
            var userData = HttpContext.Session.GetString("UserData");
            if (userData == null)
                return RedirectToAction("Index", "Login");

            var user = JsonSerializer.Deserialize<LoginApiResponse>(userData);
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
