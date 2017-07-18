using Aire.Domain;
using NUnit.Framework;
using System.Linq;

namespace Aire.GovernorTests.Providers
{
    [TestFixture]
    public  class ProviderTestBase<T> where T: IDecisionProvider, new()
    {
        protected IDecisionProvider _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new T();
        }

        [Test]
        public void DecideEmptyApplicationsYieldsEmptyEvents()
        {
            var actual = _sut.Decide(Enumerable.Empty<LoopApplication>());
            CollectionAssert.IsEmpty(actual);
        }

    }
}
