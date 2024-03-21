namespace Auth.Application.Exceptions;

public class InvalidTokenException : AuthenticationExceptionBase
{
    public InvalidTokenException()
        : base("Invalid token.")
    {
    }
}
