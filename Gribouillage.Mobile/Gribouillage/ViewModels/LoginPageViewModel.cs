using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Logging;
using Prism.Services;
using Prism.Mvvm;
using Gribouillage.Models;
using Gribouillage.Common;

namespace Gribouillage.ViewModels
{
  public class LoginPageViewModel : BindableBase
  {
    public FirebaseModel _firebaseModel = new FirebaseModel();

    #region Properties
    public string Email
    {
      get => this._firebaseModel.Email;
      set => this._firebaseModel.Email = value;
    }

    public string Password
    {
      get => this._firebaseModel.Password;
      set => this._firebaseModel.Password = value;
    }

    public string AuthMessage
    {
      get => this._firebaseModel.AuthMessage;
      set => this._firebaseModel.AuthMessage = value;
    }

    public DelegateCommand SignInByEmailAndPasswordCommand { get; }

    public DelegateCommand SignUpByEmailAndPasswordCommand { get; }
    #endregion

    #region Constructer
    public LoginPageViewModel()
    {
      this.SignInByEmailAndPasswordCommand = new DelegateCommand(async () => await SignInByEmailAndPasswordAction());
      this.SignUpByEmailAndPasswordCommand = new DelegateCommand(async () => await SignUpByEmailAndPasswordAction());
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
