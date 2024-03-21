namespace Auth.Application.Exceptions;

public class TokenExpiredException : AuthenticationExceptionBase
{
    public TokenExpiredException() : base("Token has expired")
    {
    }
}   
