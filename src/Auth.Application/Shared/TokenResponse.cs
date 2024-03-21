namespace Auth.Application.Shared;

public class TokenResponse
{
    public string AccessToken { get; set; }
    public int ExpiresInMinutes { get; set; }
    public UserToken UserToken { get; set; }
    public string RefreshToken { get; set; }
    public int RefreshTokenExpiresInMinutes { get; set; }
}
