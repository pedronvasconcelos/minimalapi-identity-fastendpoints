namespace Auth.Application.Exceptions;

public class InvalidLoginAttempt : AuthenticationExceptionBase
{
    public InvalidLoginAttempt()
        : base("Incorrect email or password. Please try again.")
    {
    }
}
