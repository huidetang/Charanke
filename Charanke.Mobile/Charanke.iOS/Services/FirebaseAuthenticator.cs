using System;
using System.Threading.Tasks;
using Charanke.Services;
using Firebase.Auth;


namespace Charanke.iOS.Services
{
  public class FirebaseAuthenticator : IFirebaseAuthenticator
  {
    public async Task<string> LoginWithEmailPassword(string email, string password)
    {
      var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
      return await user.User.GetIdTokenAsync();
    }

    public async Task CreateUserWithEmailPassword(string email, string password)
    {
      var user = await Auth.DefaultInstance.CreateUserAsync(email, password);
    }
  }
}
