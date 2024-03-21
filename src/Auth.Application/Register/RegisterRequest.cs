namespace Auth.Application.Register;

public class RegisterRequest
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public RegisterRequest(string email, string username, string password)
    {
        Email = email;
        Username = username;
        Password = password;
    }

}
