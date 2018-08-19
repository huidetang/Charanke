using NUnit.Framework;

namespace Gribouillage.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}