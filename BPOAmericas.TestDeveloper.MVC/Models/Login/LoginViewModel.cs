namespace BPOAmericas.TestDeveloper.MVC.Models.Login
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginApiRequest
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string ClientIP { get; set; }
        public string UserAgent { get; set; }
    }

    public class LoginApiResponse
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string UserProfile { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
