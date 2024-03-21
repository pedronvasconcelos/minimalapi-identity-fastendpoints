namespace Auth.Application.Exceptions;

public class RegistrationFailedException : AuthenticationExceptionBase
{
    public RegistrationFailedException(string message) : base(message)
    {
    }
}
