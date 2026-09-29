using BPOAmericas.TestDeveloper.Application.DTOs.Security;

namespace BPOAmericas.TestDeveloper.Application.Services.TokenService.Interface
{
    public interface ITokenService
    {
        string GetToken(LoginUserResponseDto responseDto);
    }
}
