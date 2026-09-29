using BPOAmericas.TestDeveloper.MVC.Models.Login;
using BPOAmericas.TestDeveloper.MVC.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BPOAmericas.TestDeveloper.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthService _authApiService;

        public LoginController(AuthService authApiService)
        {
            _authApiService = authApiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var clientIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1";
            var userAgent = Request.Headers["User-Agent"].ToString();

            var (response, token) = await _authApiService.LoginAsync(model.Email, model.Password, clientIp, userAgent);

            if (response == null)
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                return View(model);
            }

            // Guardamos en sesión para la página de bienvenida
            HttpContext.Session.SetString("UserData", JsonSerializer.Serialize(response));
            HttpContext.Session.SetString("Token", token ?? "");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
