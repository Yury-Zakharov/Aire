using Aire.Domain;
using Aire.Governor.Providers;
using NUnit.Framework;

namespace Aire.GovernorTests.Providers
{
    /// <summary>
    /// This is a dummy test for dummy provider.
    /// </summary>
    [TestFixture]
    public class DummyProviderTests: ProviderTestBase<DummyProvider>
    {
        [Test]
        public void DecideNonEmptyCollectionYieldsResult()
        {
            var applications = new[]
            {
                new LoopApplication()
            };

            var actual = _sut.Decide(applications);
            CollectionAssert.IsNotEmpty(actual);
        }
        
    }
}