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
using Gribouillage.Models;
using Gribouillage.Common;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Gribouillage.ViewModels
{
  public class LoginPageViewModel : BindableBase
  {
    public FirebaseModel _firebaseModel = new FirebaseModel();

    #region Properties
    [Required(ErrorMessage = "メールアドレスを入力してください。")]
    public ReactiveProperty<string> Email { get; }
      = new ReactiveProperty<string>();

    [Required(ErrorMessage = "パスワードを入力してください。")]
    public ReactiveProperty<string> Password { get; }
      = new ReactiveProperty<string>();

    public ReadOnlyReactiveProperty<string> AuthMessage { get; }

    public ReactiveCommand SendSignInByEmailAndPassword { get; }

    public ReactiveCommand SendSignUpByEmailAndPassword { get; }
    #endregion

    #region Constructer
    public LoginPageViewModel()
    {
      _firebaseModel = new FirebaseModel();

      Email = ReactiveProperty.FromObject(
        _firebaseModel,
        x => x.Email);

      Password = ReactiveProperty.FromObject(
        _firebaseModel,
        x => x.Password);

      AuthMessage = _firebaseModel.ObserveProperty(m => m.AuthMessage)
                                  .ToReadOnlyReactiveProperty();

      SendSignInByEmailAndPassword = Email.ObserveHasErrors.CombineLatest(
        Password.ObserveHasErrors, (x, y) => !x && !y)
                                          .ToReactiveCommand();

      SendSignUpByEmailAndPassword = Email.ObserveHasErrors.CombineLatest(
        Password.ObserveHasErrors, (x, y) => !x && !y)
                                          .ToReactiveCommand();

      SendSignInByEmailAndPassword.Subscribe(
        async _ => await this.SignInByEmailAndPasswordAction());

      SendSignUpByEmailAndPassword.Subscribe(
        async _ => await this.SignUpByEmailAndPasswordAction());
    }
    #endregion

    #region Command
    private async Task SignInByEmailAndPasswordAction()
    {
      await this._firebaseModel.SignInByEmailAndPasswordAsync();
    }

    private async Task SignUpByEmailAndPasswordAction()
    {
      await this._firebaseModel.SignUpByEmailAndPasswordAsync();
    }

    #endregion
  }
}
