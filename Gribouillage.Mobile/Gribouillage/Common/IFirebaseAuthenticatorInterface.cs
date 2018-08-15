using System;
using System.Threading.Tasks;

namespace Gribouillage.Common
{
  public interface IFirebaseAuthenticator
  {
    Task<string> LoginWithEmailPassword(string email, string password);
  }
}
