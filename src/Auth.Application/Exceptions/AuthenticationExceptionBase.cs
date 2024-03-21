using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Exceptions;

public class AuthenticationExceptionBase
    : Exception
{
    public AuthenticationExceptionBase(string message) : base(message)
    {
    }
}
