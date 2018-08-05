using System;
namespace Gribouillage.Models
{
  public static class VisualStudioAppCenterToken
  {
    public static string AndroidKey => Environment.GetEnvironmentVariable("VsacAndroidKey");

    public static string IOsKey => Environment.GetEnvironmentVariable("VsacIosKey");
  }
}
