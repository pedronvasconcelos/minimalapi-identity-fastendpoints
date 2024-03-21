namespace Auth.Application.Login;

public class LoginResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public int ExpiresInMinutes { get; set; }

    public LoginResponse(string token, string refreshToken, int expires)
    {
        Token = token;
        RefreshToken = refreshToken;
        ExpiresInMinutes = expires;
    }
}
