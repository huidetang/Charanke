using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Charanke.Services;
using Firebase.Auth;

namespace Charanke.Droid.Services
{
  public class FirebaseAuthenticator : IFirebaseAuthenticator
  {
    public async Task<string> LoginWithEmailPassword(string email, string password)
    {
      try
      {
        var user = await FirebaseAuth.Instance
        .SignInWithEmailAndPasswordAsync(email, password);
        var token = await user.User.GetIdTokenAsync(false);
        return token.Token;
      }
      catch (Exception ex)
      {
        throw new AuthFailureException(ex.Message, ex);
      }
    }

    public async Task CreateUserWithEmailPassword(string email, string password)
    {
      try
      {
        var user = await FirebaseAuth.Instance
          .CreateUserWithEmailAndPasswordAsync(email, password);
      }
      catch (Exception ex)
      {
        throw new AuthFailureException(ex.Message, ex);
      }
    }
  }
}
