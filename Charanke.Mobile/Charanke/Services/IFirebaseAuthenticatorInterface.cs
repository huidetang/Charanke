using System;
using System.Threading.Tasks;

namespace Charanke.Services
{
  /// <summary>
  /// Firebase authenticator.
  /// </summary>
  public interface IFirebaseAuthenticator
  {
    /// <summary>
    /// Logins the with email password.
    /// </summary>
    /// <returns>The with email password.</returns>
    /// <param name="email">Email.</param>
    /// <param name="password">Password.</param>
    Task<string> LoginWithEmailPassword(string email, string password);
  }
}
