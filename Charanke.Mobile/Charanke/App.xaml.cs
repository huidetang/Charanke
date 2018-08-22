using Prism;
using Prism.Ioc;
using Charanke.ViewModels;
using Charanke.Views;
using Charanke.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Reflection;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Charanke
{
  public partial class App : PrismApplication
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Charanke.App"/> class.
    /// The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
    /// This imposes a limitation in which the App class must have a default constructor.
    /// App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
    /// </summary>
    public App() : this(null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Charanke.App"/> class.
    /// </summary>
    /// <param name="initializer">Initializer.</param>
    public App(IPlatformInitializer initializer) : base(initializer) { }

    /// <summary>
    /// On initialized.
    /// </summary>
    protected override async void OnInitialized()
    {
      InitializeComponent();

      await NavigationService.NavigateAsync("NavigationPage/LoginPage");
    }

    /// <summary>
    /// On start.
    /// </summary>
    protected override void OnStart()
    {
      base.OnStart();

      AppCenter.Start("ios=" + VisualStudioAppCenterToken.IosKey + ";" +
                      "android="+ VisualStudioAppCenterToken.AndroidKey + ";",
                typeof(Analytics), typeof(Crashes));
    }

    /// <summary>
    /// On sleep.
    /// </summary>
    protected override void OnSleep()
    {
      base.OnSleep();
    }

    /// <summary>
    /// On resume.
    /// </summary>
    protected override void OnResume()
    {
      base.OnResume();
    }

    /// <summary>
    /// Register types.
    /// </summary>
    /// <param name="containerRegistry">Container registry.</param>
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainPage>();
      containerRegistry.RegisterForNavigation<LoginPage>();
    }
  }
}
