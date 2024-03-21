namespace Auth.Application.Exceptions;

public class RefreshTokenRequiredException : AuthenticationExceptionBase
{
    public RefreshTokenRequiredException()
        : base("Refresh token is required.")
    {
    }
}