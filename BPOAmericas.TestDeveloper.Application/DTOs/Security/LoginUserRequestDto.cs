namespace BPOAmericas.TestDeveloper.Application.DTOs.Security
{
    public class LoginUserRequestDto
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string CLientIP { get; set; }
        public string UserAgent { get; set; }
    }
}
