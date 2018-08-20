using System;
using dotenv.net;

namespace Charanke.Models
{
  /// <summary>
  /// Visual Studio App Center token.
  /// </summary>
  public static class VisualStudioAppCenterToken
  {
    /// <summary>
    /// Gets the VSAC key for Android.
    /// </summary>
    /// <value>The VSAC key for Android.</value>
    public static string AndroidKey => "VsacAndroidKey";

    /// <summary>
    /// Gets the VSAC key for iOS.
    /// </summary>
    /// <value>The VSAC key for iOS.</value>
    public static string IosKey => "VsacIosKey";
  }
}
