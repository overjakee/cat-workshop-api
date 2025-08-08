namespace cat_workshop_api.DTOs.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; } = "";
        public int UserId { get; set; }
        public string UserName { get; set; } = "";
    }
}
