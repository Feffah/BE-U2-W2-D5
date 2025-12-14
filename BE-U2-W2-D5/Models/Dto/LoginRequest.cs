namespace BE_U2_W2_D5.Models.Dto
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public bool LockOutOnFailure { get; set; }
    }
}
