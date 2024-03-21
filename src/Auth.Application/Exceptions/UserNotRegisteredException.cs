namespace Auth.Application.Exceptions;

public class UserNotRegisteredException : AuthenticationExceptionBase
{
    public UserNotRegisteredException()
        : base("User not registered. Please register before logging in.")
    {
    }
}
