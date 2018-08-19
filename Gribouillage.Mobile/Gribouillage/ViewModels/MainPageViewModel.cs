using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gribouillage.ViewModels
{
  /// <summary>
  /// Main page view model.
  /// </summary>
  public class MainPageViewModel : ViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gribouillage.ViewModels.MainPageViewModel"/> class.
    /// </summary>
    /// <param name="navigationService">Navigation service.</param>
    public MainPageViewModel(INavigationService navigationService)
        : base(navigationService)
    {
      Title = "Main Page";
    }
  }
}
