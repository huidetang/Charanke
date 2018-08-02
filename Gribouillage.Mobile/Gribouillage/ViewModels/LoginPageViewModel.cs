using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Logging;
using Prism.Services;
using Gribouillage.Models;
using Gribouillage.Common;

namespace Gribouillage.ViewModels
{
  public class LoginPageViewModel : ViewModelBase, INotifyPropertyChanged
  {
    private readonly FirebaseModel _firebaseModel = new FirebaseModel();

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

    public string AuthMessage => this._firebaseModel.AuthMessage;
    #endregion

    #region Constructer
    public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
    {

    }
    #endregion

    #region Command
    /// <summary>
    /// Sign in.
    /// </summary>
    /// <value>Sign in by email and password.</value>
    public RelayCommand SignInByEmailAndPasswordCommand
    {
      get => this._signInByEmailAndPasswordCommand ?? new RelayCommand(async () =>
      {
        await this._firebaseModel.SignInByEmailAndPasswordAsync();
      });
    }

    private RelayCommand _signInByEmailAndPasswordCommand;

    /// <summary>
    /// Sign up.
    /// </summary>
    /// <value>Sign up by email and password.</value>
    public RelayCommand SignUpByEmailAndPasswordCommand
    {
      get => this._signUpByEmailAndPasswordCommand ?? new RelayCommand(async () =>
      {
        await this._firebaseModel.SignUpByEmailAndPasswordAsync();
      });
    }

    private RelayCommand _signUpByEmailAndPasswordCommand;
    #endregion

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      this.PropertyChanged?.Invoke(this, e);
    }

    #endregion
  }
}
