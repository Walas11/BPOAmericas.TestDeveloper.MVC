using BPOAmericas.TestDeveloper.Application.DTOs.Security;
using BPOAmericas.TestDeveloper.Application.Services.Security.Interface;
using BPOAmericas.TestDeveloper.Common.Services;

namespace BPOAmericas.TestDeveloper.Application.Services.Security
{
    public class SecurityService : IsecurityService
    {
        public LoginUserResponseDto LoginUser(LoginUserRequestDto requestDto)
        {
            string UserName = GeneralServices.Decode(requestDto.UserName);
            string UserPassword = GeneralServices.Decode(requestDto.UserPassword);

            if (UserName == "BPOAmericas@bpoamericas.com" && UserPassword == "BPOAmericas2026*")
            {
                var response = new LoginUserResponseDto
                {
                    IdUser = 5,
                    UserName = "TEST USER",
                    UserProfile = "lowlevel",
                    LastLoginDate = DateTime.Now
                };

                return response;
            }

            throw new UnauthorizedAccessException("Usuario o Contraseña incorrecta");
        }
    }
}
