using BPOAmericas.TestDeveloper.Application.DTOs.Security;
using BPOAmericas.TestDeveloper.Application.Services.Security.Interface;
using BPOAmericas.TestDeveloper.Application.Services.TokenService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BPOAmericas.TestDeveloper.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly IsecurityService _isecurityService;
        private readonly ITokenService _tokenService;

        public SecurityController(IsecurityService isecurityService, ITokenService tokenService)
        {
            _isecurityService = isecurityService;
            _tokenService = tokenService;
        }

        [HttpPost("LoginUser")]
        public IActionResult LoginUser([FromBody] LoginUserRequestDto loginUserRequestDto) 
        {
            try
            {
                var result = _isecurityService.LoginUser(loginUserRequestDto);
                var token = _tokenService.GetToken(result);

                Response.Headers.Append("Authorization", $"Bearer {token}");

                return Ok(result);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { message = "Credenciales inválidas" });
            }
        }
    }
}
