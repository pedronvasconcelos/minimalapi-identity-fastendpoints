namespace Auth.Application.Exceptions;

public class LogoutFailedException : AuthenticationExceptionBase
{
    public LogoutFailedException() : base("Failed to log out")
    {
    }
}   