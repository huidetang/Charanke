using System;
namespace Charanke.iOS.Services
{
  public class AuthFailureException : Exception
  {
    public AuthFailureException()
    {
    }

    public AuthFailureException(string message) : base(message)
    {
    }

    public AuthFailureException(string message, Exception inner)
      : base(message, inner)
    {

    }
  }
}
