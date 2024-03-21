namespace Auth.Application.Exceptions;

public class AccountLockedException : AuthenticationExceptionBase
{
    public AccountLockedException()
        : base("Account locked due to multiple failed login attempts. Please contact support.")
    {
    }
}
