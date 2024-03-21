namespace Auth.Application.Exceptions;

public class InvalidRefreshTokenException : AuthenticationExceptionBase
{
    public InvalidRefreshTokenException()
        : base("Invalid refresh token.")
    {
    }
}   