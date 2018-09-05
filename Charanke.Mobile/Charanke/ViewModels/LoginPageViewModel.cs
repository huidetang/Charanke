using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;
using Prism.Commands;
using Prism.Navigation;
using Prism.Logging;
using Prism.Services;
using Prism.Mvvm;
using Prism.Events;
using Charanke.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.ComponentModel.DataAnnotations;
using Charanke.Services;

namespace Charanke.ViewModels
{
  /// <summary>
  /// Login page view model.
  /// </summary>
  public class LoginPageViewModel : BindableBase
  {
    #region Properties
    /// <summary>
    /// Gets the email address.
    /// </summary>
    /// <value>The email address.</value>
    [Required(ErrorMessage = "メールアドレスを入力してください。")]
    public ReactiveProperty<string> Email { get; }
      = new ReactiveProperty<string>();

    /// <summary>
    /// Gets the password.
    /// </summary>
    /// <value>The password.</value>
    [Required(ErrorMessage = "パスワードを入力してください。")]
    public ReactiveProperty<string> Password { get; }
      = new ReactiveProperty<string>();

    /// <summary>
    /// Gets the message for authentication.
    /// </summary>
    /// <value>The message for authentication.</value>
    public ReadOnlyReactiveProperty<string> AuthMessage { get; }

    /// <summary>
    /// Set command of sign in by email and password.
    /// </summary>
    /// <value>Command of sign in by email and password.</value>
    public ReactiveCommand SendSignInByEmailAndPassword { get; }

    /// <summary>
    /// Set command of sign up by email and password.
    /// </summary>
    /// <value>Command of sign up by email and password.</value>
    public ReactiveCommand SendSignUpByEmailAndPassword { get; }
    #endregion

    private IFirebaseAuthenticator FirebaseAuthenticator { get; }



    /// <summary>
    /// The firebase model.
    /// </summary>
    public FirebaseAuthenticationModel _AuthModel;



    #region Constructer

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Charanke.ViewModels.LoginPageViewModel"/> class.
    /// </summary>
    public LoginPageViewModel(IFirebaseAuthenticator firebaseAuthenticator)
    {
      FirebaseAuthenticator = firebaseAuthenticator;

      _AuthModel = new FirebaseAuthenticationModel(FirebaseAuthenticator);

      Email = ReactiveProperty.FromObject(
        _AuthModel,
        x => x.Email);

      Password = ReactiveProperty.FromObject(
        _AuthModel,
        x => x.Password);

      AuthMessage = _AuthModel.ObserveProperty(m => m.AuthMessage)
                                  .ToReadOnlyReactiveProperty();

      SendSignInByEmailAndPassword = Email.ObserveHasErrors.CombineLatest(
        Password.ObserveHasErrors, (x, y) => !x && !y)
                                          .ToReactiveCommand();

      SendSignUpByEmailAndPassword = Email.ObserveHasErrors.CombineLatest(
        Password.ObserveHasErrors, (x, y) => !x && !y)
                                          .ToReactiveCommand();

      SendSignInByEmailAndPassword.Subscribe(
        async () => await this.SignInByEmailAndPasswordAction());

      SendSignUpByEmailAndPassword.Subscribe(
        async () => await this.SignUpByEmailAndPasswordAction());
    }
    #endregion

    #region Command
    /// <summary>
    /// The action of sign in by email and password.
    /// </summary>
    /// <returns>The action of sign in by email and password.</returns>
    private async Task SignInByEmailAndPasswordAction()
    {
      await this._AuthModel.SignInByEmailAndPasswordAsync();
    }

    /// <summary>
    /// The action of sign up by email and password.
    /// </summary>
    /// <returns>The action of sign up by email and password.</returns>
    private async Task SignUpByEmailAndPasswordAction()
    {
      await this._AuthModel.SignUpByEmailAndPasswordAsync();
    }

    #endregion
  }
}
