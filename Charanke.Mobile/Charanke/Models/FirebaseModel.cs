using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Firebase.Auth;
using System.Linq;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace Charanke.Models
{
  /// <summary>
  /// Firebase model.
  /// </summary>
  public class FirebaseModel : BindableBase
  {
    #region Property
    /// <summary>
    /// Email Address for Login.
    /// </summary>
    /// <value>The Email Address.</value>
    public string Email
    {
      get => this._email;
      set => this.SetProperty(ref this._email, value);
    }

    /// <summary>
    /// Deault Email Address.
    /// </summary>
    private string _email = "";

    /// <summary>
    /// Password for Login.
    /// </summary>
    /// <value>The password.</value>
    public string Password
    {
      get => this._password;
      set => this.SetProperty(ref this._password, value);
    }

    /// <summary>
    /// Default Password.
    /// </summary>
    private string _password = "";

    /// <summary>
    /// Auth Message.
    /// </summary>
    /// <value>Auth message.</value>
    public string AuthMessage
    {
      get => this._authMessage;
      set => this.SetProperty(ref this._authMessage, value);
    }

      /// <summary>
      /// default auth message.
      /// </summary>
    private string _authMessage;

    #endregion

    #region Variables
    /// <summary>
    /// Firebase認証へのリンク
    /// </summary>
    private FirebaseAuthLink _authLink;
    #endregion

    #region Methods

    /// <summary>
    /// Sign in by Email Address and Password async.
    /// </summary>
    /// <returns>Task</returns>
    public async Task SignInByEmailAndPasswordAsync()
    {
      try
      {
        var auth = new FirebaseAuthProvider(new FirebaseConfig(FirebaseToken.ApiKey));

        this._authLink = await auth.SignInWithEmailAndPasswordAsync(this.Email, this.Password);

        this.AuthMessage = "サインインに成功しました。";
      }
      catch (FirebaseAuthException ex)
      {
        this.AuthMessage = "サインインできませんでした。エラーコード：" + ex.Reason;
      }
    }

    /// <summary>
    /// Sign Up by Email Address and Password async.
    /// </summary>
    /// <returns>Task</returns>
    public async Task SignUpByEmailAndPasswordAsync()
    {
      try
      {
        var auth = new FirebaseAuthProvider(new FirebaseConfig(FirebaseToken.ApiKey));

        this._authLink = await auth.CreateUserWithEmailAndPasswordAsync(this.Email, this.Password);

        this.AuthMessage = "ユーザー作成に成功しました。";
        }
      catch (FirebaseAuthException ex)
      {
        this.AuthMessage = "ユーザー作成できませんでした。エラーコード：" + ex.Reason;
      }
    }
    #endregion
  }
}
