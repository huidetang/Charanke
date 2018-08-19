using Prism;
using Prism.Ioc;
using Prism.Logging;

namespace Gribouillage.Tests.Mocks
{
    public class NUnitPlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILoggerFacade, TraceLogger>();
        }
    }
}
