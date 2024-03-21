namespace Auth.Application.Exceptions;

public class UserNotConfirmedException : AuthenticationExceptionBase
{
    public UserNotConfirmedException()
        : base("User account not confirmed. Please check your email to confirm your account.")
    {
    }
}