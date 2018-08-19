using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;

namespace Gribouillage.Droid
{
  /// <summary>
  /// Main activity.
  /// </summary>
  [Activity(Label = "Gribouillage", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    /// <summary>
    /// Ons the create.
    /// </summary>
    /// <param name="bundle">Bundle.</param>
    protected override void OnCreate(Bundle bundle)
    {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(bundle);

      global::Xamarin.Forms.Forms.Init(this, bundle);
      LoadApplication(new App(new AndroidInitializer()));
    }
  }

  /// <summary>
  /// Android initializer.
  /// </summary>
  public class AndroidInitializer : IPlatformInitializer
  {
    /// <summary>
    /// Registers the types.
    /// </summary>
    /// <param name="containerRegistry">Container registry.</param>
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Register any platform specific implementations
    }
  }
}

