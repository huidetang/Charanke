using Prism.Events;

namespace Gribouillage.Common
{
  public class Messenger : EventAggregator
  {
    private static Messenger _instance;

    public static Messenger Instance
    {
      get { return _instance ?? (_instance = new Messenger()); }
    }
  }
}