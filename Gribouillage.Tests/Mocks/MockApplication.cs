using Prism;
using Prism.DryIoc;
using Prism.Ioc;

namespace Gribouillage.Tests.Mocks
{
    public class MockApplication : PrismApplication
    {
        public MockApplication(IPlatformInitializer platformInitializer)
            : base(platformInitializer)
        {
        }

        protected override void OnInitialized()
        {

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
