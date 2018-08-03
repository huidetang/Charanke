using Prism;
using Prism.Ioc;
using Gribouillage.ViewModels;
using Gribouillage.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using dotenv.net;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Gribouillage
{
  public partial class App : PrismApplication
  {
    /* 
     * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
     * This imposes a limitation in which the App class must have a default constructor. 
     * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
     */
    public App() : this(null) { }

    public App(IPlatformInitializer initializer) : base(initializer) { }

    protected override async void OnInitialized()
    {
      InitializeComponent();

      await NavigationService.NavigateAsync("NavigationPage/LoginPage");
    }

    protected override void OnStart()
    {
      base.OnStart();

      var rootFolder = Environment.GetFolderPath(Gribouillage);

      DotEnv.Config(true);

      AppCenter.Start("ios=" + Environment.GetEnvironmentVariable("AppCenterIOsKey") +
                      "android="+ Environment.GetEnvironmentVariable("AppCenterAndroidKey"),
                typeof(Analytics), typeof(Crashes));
    }

    protected override void OnSleep()
    {
      base.OnSleep();
    }

    protected override void OnResume()
    {
      base.OnResume();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainPage>();
    }
  }
}
