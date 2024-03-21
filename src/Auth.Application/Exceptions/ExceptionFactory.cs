using Microsoft.AspNetCore.Identity;

namespace Auth.Application.Exceptions;

public static class ExceptionFactory
{
    public static AuthenticationExceptionBase InvalidLoginAttempt()
    {
        return new InvalidLoginAttempt();
    }


    public static AuthenticationExceptionBase UserNotRegistered()
    {
        return new UserNotRegisteredException();
    }

    public static AuthenticationExceptionBase AccountLocked()
    {
        return new AccountLockedException();
    }

    public static AuthenticationExceptionBase UserNotConfirmed()
    {
        return new UserNotConfirmedException();
    }

    public static AuthenticationExceptionBase InvalidRefreshToken()
    {
        return new InvalidRefreshTokenException();
    }
    public static AuthenticationExceptionBase RefreshTokenRequired()
    {
        return new RefreshTokenRequiredException(); 
    }
    public static AuthenticationExceptionBase InvalidToken()
    {
        return new InvalidTokenException();
    }
    public static AuthenticationExceptionBase TokenExpired()
    {
        return new TokenExpiredException();
    }   

    public static AuthenticationExceptionBase RefreshTokenExpired()
    {
        return new RefreshTokenExpiredException();
    }
    public static RegistrationFailedException RegistrationFailed(IEnumerable<IdentityError>errors)
    {
        string errorMessage = string.Join(Environment.NewLine, errors.Select(x => x.Description));
        return new RegistrationFailedException(errorMessage);
    }

    public static LogoutFailedException LogoutFailed()
    {
        return new LogoutFailedException();
    }
}
