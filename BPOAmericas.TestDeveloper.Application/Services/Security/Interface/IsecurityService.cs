using BPOAmericas.TestDeveloper.Application.DTOs.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPOAmericas.TestDeveloper.Application.Services.Security.Interface
{
    public interface IsecurityService
    {
        LoginUserResponseDto LoginUser(LoginUserRequestDto loginUserRequest);
    }
}
