using Aire.Domain;
using Aire.Services.Infrastructure;
using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace Aire.Services.Tests
{
    [TestFixture()]
    public class LoopServiceTests
    {
        private ILoopService _sut;
        private IDataProvider _dataProvider;
        private IGovernor _governor;

        [SetUp]
        public void SetUp()
        {
            _dataProvider = MockRepository.GenerateMock<IDataProvider>();
            _governor = MockRepository.GenerateMock<IGovernor>();
            _sut = new LoopService(_dataProvider,_governor);
        }

        [TearDown]
        public void TearDown()
        {
            _dataProvider.VerifyAllExpectations();
            _governor.VerifyAllExpectations();
        }

        [Test()]
        public void AddApplicationCallsDataProvider()
        {
            var application = new LoopApplication { Applicant = "Вася Пупкин", Amount = 100500m };
            _dataProvider.Expect(m => m.AddApplication(application))
                .Repeat.Once();                
            _sut.AddApplication(application);
        }

        [Test()]
        public void GetEventsCallsDataProviderAndPassesResultToGovernor()
        {
            IEnumerable<LoopApplication> applications = new[]
            {
                new LoopApplication()
            };
            IEnumerable<LoopEvent> events = new[]
            {
                new LoopEvent(),
                new LoopEvent()
            };
            _dataProvider.Expect(m => m.GetApplications())
                .Repeat.Once()
                .Return(applications);
            _governor.Expect(m => m.Decide(applications))
                .Repeat.Once()
                .Return(events);

            var actual = _sut.GetEvents();
            Assert.DoesNotThrow(() => actual.ToList());
            CollectionAssert.AreEqual(events, actual);
        }
    }
}