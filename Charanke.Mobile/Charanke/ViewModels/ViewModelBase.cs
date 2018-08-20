using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charanke.ViewModels
{
  /// <summary>
  /// View model base.
  /// </summary>
  public class ViewModelBase : BindableBase, INavigationAware, IDestructible
  {
    /// <summary>
    /// Gets the navigation service.
    /// </summary>
    /// <value>The navigation service.</value>
    protected INavigationService NavigationService { get; private set; }

    /// <summary>
    /// The title.
    /// </summary>
    private string _title;

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    public string Title
    {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Charanke.ViewModels.ViewModelBase"/> class.
    /// </summary>
    /// <param name="navigationService">Navigation service.</param>
    public ViewModelBase(INavigationService navigationService)
    {
      NavigationService = navigationService;
    }

    /// <summary>
    /// Ons the navigated from.
    /// </summary>
    /// <param name="parameters">Parameters.</param>
    public virtual void OnNavigatedFrom(NavigationParameters parameters)
    {

    }

    /// <summary>
    /// Ons the navigated to.
    /// </summary>
    /// <param name="parameters">Parameters.</param>
    public virtual void OnNavigatedTo(NavigationParameters parameters)
    {

    }

    /// <summary>
    /// Ons the navigating to.
    /// </summary>
    /// <param name="parameters">Parameters.</param>
    public virtual void OnNavigatingTo(NavigationParameters parameters)
    {

    }

    /// <summary>
    /// Destroy this instance.
    /// </summary>
    public virtual void Destroy()
    {

    }
  }
}
