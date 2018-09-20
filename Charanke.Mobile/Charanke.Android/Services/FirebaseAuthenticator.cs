using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Charanke.Services;
using Firebase.Auth;
using Android.Runtime;

namespace Charanke.Droid.Services
{
  public class FirebaseAuthenticator : IFirebaseAuthenticator
  {
    public async Task<(string token, string uid, string userName, string photoUrl)>
    LoginWithEmailPassword(string email, string password)
    {
      try
      {
        var user = await FirebaseAuth.Instance
        .SignInWithEmailAndPasswordAsync(email, password);
        var token = await user.User.GetIdTokenAsync(false);
        return (token.Token,
                user.User.Uid,
                user.User.DisplayName,
                user.User.PhotoUrl.ToString());
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
