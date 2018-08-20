using Prism;
using Prism.Ioc;
using Prism.Logging;

namespace Charanke.Tests.Mocks
{
    public class NUnitPlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILoggerFacade, TraceLogger>();
        }
    }
}
