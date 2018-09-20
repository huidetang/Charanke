using System;
using System.Threading.Tasks;
using Charanke.Services;
using Firebase.Auth;
using Foundation;

namespace Charanke.iOS.Services
{
  public class FirebaseAuthenticator : IFirebaseAuthenticator
  {
    public async Task<(string token, string uid, string userName, string photoUrl)>
    LoginWithEmailPassword(string email, string password)
    {
      try
      {
        var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
        var token = await user.User.GetIdTokenAsync();
        return (token,
                user.User.Uid,
                user.User.DisplayName,
                user.User.PhotoUrl.ToString());
      }
      catch (NSErrorException ex)
      {
        throw new AuthFailureException(ex.Error.LocalizedDescription, ex);
      }
    }


    public async Task CreateUserWithEmailPassword(string email, string password)
    {
      try
      {
        var user = await Auth.DefaultInstance.CreateUserAsync(email, password);
      }
      catch (NSErrorException ex)
      {
        throw new AuthFailureException(ex.Error.LocalizedDescription, ex);
      }
    }
  }
}