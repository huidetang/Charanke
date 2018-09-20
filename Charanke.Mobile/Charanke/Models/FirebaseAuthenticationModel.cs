using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Charanke.Services;
using Charanke.ViewModels;
using Microsoft.AppCenter.Crashes;

namespace Charanke.Models
{
  /// <summary>
  /// Firebase model.
  /// </summary>
  public class FirebaseAuthenticationModel : BindableBase
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

    private IFirebaseAuthenticator FirebaseAuthenticator { get; }

    private string _token;
    public string Token
    {
      get => this._token;
      set => this.SetProperty(ref this._token, value);
    }

    private string _uid;
    public string UId
    {
      get => this._uid;
      set => this.SetProperty(ref this._uid, value);
    }

    private string _userName;
    public string UserName
    {
      get => this._userName;
      set => this.SetProperty(ref this._userName, value);
    }

    private Uri _photoUrl;
    public Uri PhotoUrl
    {
      get => this._photoUrl;
      set => this.SetProperty(ref this._photoUrl, value);
    }
    #endregion

    #region Variables
    #endregion

    #region Methods

    public FirebaseAuthenticationModel(IFirebaseAuthenticator firebaseAuthenticator)
    {
      this.FirebaseAuthenticator = firebaseAuthenticator;
    }

    /// <summary>
    /// Sign in by Email Address and Password async.
    /// </summary>
    /// <returns>Task</returns>
    public async Task SignInByEmailAndPasswordAsync()
    {
      try
      {
        var authData = await FirebaseAuthenticator
          .LoginWithEmailPassword(this.Email, this.Password);

        this.Token = authData.token;
        this.UId = authData.uid;
        this.UserName = authData.userName;
        this.PhotoUrl = new Uri(authData.photoUrl);

        this.AuthMessage = "サインインに成功しました。";
      }
      catch (AuthFailureException ex)
      {
        this.AuthMessage = "サインインできませんでした。\nメッセージ：" + ex.Message;

        Crashes.TrackError(ex);
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
        await FirebaseAuthenticator
          .CreateUserWithEmailPassword(this.Email, this.Password);

        this.AuthMessage = "ユーザー作成に成功しました。";
      }
      catch (AuthFailureException ex)
      {
        this.AuthMessage = "ユーザー作成できませんでした。\nメッセージ：" + ex.Message;

        Crashes.TrackError(ex);
      }
    }
    #endregion
  }
}
