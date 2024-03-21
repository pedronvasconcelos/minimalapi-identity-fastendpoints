namespace Auth.Application.Exceptions;

public class RefreshTokenExpiredException : AuthenticationExceptionBase
{
    public RefreshTokenExpiredException() : base("Refresh token has expired")
    {
    }
}   