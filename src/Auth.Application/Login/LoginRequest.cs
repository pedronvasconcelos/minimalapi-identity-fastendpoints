namespace Auth.Application.Login;

public class LoginRequest
{
    public string UserIdentifier { get; set; }
    public string Password { get; set; }

    public LoginRequest(string userIdentifier, string password)
    {
        UserIdentifier = userIdentifier;
        Password = password;
    }
}
