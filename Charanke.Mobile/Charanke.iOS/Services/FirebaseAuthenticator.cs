using System;
using System.Threading.Tasks;
using Charanke.Services;
using Firebase.Auth;
using Foundation;

namespace Charanke.iOS.Services
{
  public class FirebaseAuthenticator : IFirebaseAuthenticator
  {
    public async Task<string> LoginWithEmailPassword(string email, string password)
    {
      try
      {
        var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
        return await user.User.GetIdTokenAsync();
      }
      catch (NSErrorException ex)
      {
        AuthErrorCode errorCode;
        if (IntPtr.Size == 8) // 64 bits devices
          errorCode = (AuthErrorCode)((long)ex.Error.Code);
        else // 32 bits devices
          errorCode = (AuthErrorCode)((int)ex.Error.Code);

        // Posible error codes that CreateUser method could throw
        switch (errorCode)
        {
          case AuthErrorCode.OperationNotAllowed:
            throw new AuthFailureException("ログインに失敗しました。", ex);
          case AuthErrorCode.UserDisabled:
            throw new AuthFailureException("無効なユーザーです。", ex);
          case AuthErrorCode.InvalidEmail:
          case AuthErrorCode.WrongPassword:
            throw new AuthFailureException("メールアドレスもしくはパスワードが違います。", ex);
          default:
            throw new AuthFailureException("想定しないエラーが発生しました。", ex);
        }

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
        AuthErrorCode errorCode;
        if (IntPtr.Size == 8) // 64 bits devices
          errorCode = (AuthErrorCode)((long)ex.Error.Code);
        else // 32 bits devices
          errorCode = (AuthErrorCode)((int)ex.Error.Code);

        // Posible error codes that CreateUser method could throw
        switch (errorCode)
        {
          case AuthErrorCode.InvalidEmail:
            throw new AuthFailureException("正しくないメールアドレスが使われています。", ex);
          case AuthErrorCode.EmailAlreadyInUse:
            throw new AuthFailureException("このメールアドレスは既に使われています。", ex);
          case AuthErrorCode.OperationNotAllowed:
            throw new AuthFailureException("ログインに失敗しました。", ex);
          case AuthErrorCode.WeakPassword:
            throw new AuthFailureException("パスワードの強度が弱すぎます。", ex);
          default:
            throw new AuthFailureException("想定しないエラーが発生しました。", ex);
        }

      }
    }
  }
}