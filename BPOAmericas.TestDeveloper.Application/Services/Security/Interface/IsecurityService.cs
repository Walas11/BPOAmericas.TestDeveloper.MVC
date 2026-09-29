using BPOAmericas.TestDeveloper.Application.DTOs.Security;

namespace BPOAmericas.TestDeveloper.Application.Services.Security.Interface
{
    public interface IsecurityService
    {
        LoginUserResponseDto LoginUser(LoginUserRequestDto loginUserRequest);
    }
}
