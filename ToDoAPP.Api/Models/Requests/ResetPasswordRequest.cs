namespace ToDoAPP.Api.Models.Requests
{
    public class ResetPasswordRequest
    {
        public int UserID { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }

    }
}
