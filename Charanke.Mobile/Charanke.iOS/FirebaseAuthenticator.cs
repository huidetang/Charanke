using System;
using System.Threading.Tasks;
using Charanke.Models;
using Firebase.Auth;


namespace Charanke.iOS
{
  public class FirebaseAuthenticator : IFirebaseAuthenticator
  {
    public async Task<string> LoginWithEmailPassword(string email, string password)
    {
      var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
      return await user.User.GetIdTokenAsync();
    }
  }
}
