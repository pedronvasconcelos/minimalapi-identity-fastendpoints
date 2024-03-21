namespace Auth.Application.Register;

public class RegisterResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string Username { get; set; }

    public int ExpiresInMinutes { get; set; }
    public RegisterResponse(bool success, string message, string token, string refreshToken, string username, int expiresInMinutes)
    {
        Success = success;
        Message = message;
        Token = token;
        RefreshToken = refreshToken;
        Username = username;
        ExpiresInMinutes = expiresInMinutes;
    }
}
