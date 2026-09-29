using BPOAmericas.TestDeveloper.Application.DTOs.Security;
using BPOAmericas.TestDeveloper.Application.Services.TokenService.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BPOAmericas.TestDeveloper.Application.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly string _token = "BPOAmericas2026*ClaveSecretaJWT!";
        public string GetToken(LoginUserResponseDto responseDto)
        {
            var claims = new[]
            {
                new Claim("IdUser", responseDto.IdUser.ToString()),
                new Claim(ClaimTypes.Name, responseDto.UserName),
                new Claim("UserProfile", responseDto.UserProfile)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_token));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "BPOAmericas",
                audience: "BPOAmericas",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
