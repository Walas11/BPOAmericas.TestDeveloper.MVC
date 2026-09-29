namespace BPOAmericas.TestDeveloper.Application.DTOs.Security
{
    public class LoginUserResponseDto
    {
        public int IdUser { get; set; }
        public string? UserName { get; set; }
        public string? UserProfile { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
