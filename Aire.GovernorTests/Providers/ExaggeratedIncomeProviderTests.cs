using Aire.Domain;
using Aire.Governor.Providers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aire.GovernorTests.Providers
{
    [TestFixture]
    class ExaggeratedIncomeProviderTests : ProviderTestBase<ExaggeratedIncomeProvider>
    {
        [Test]
        public void EvenIncomeYieldsNoEvents()
        {
            var even = CreateEvenIncome(100000).ToList();
            var actual = _sut.Decide(even);
            CollectionAssert.IsEmpty(actual);
        }

        [Ignore("Need elaborate on the algorithm")]
        [Test]
        public void PertrudedIncomeYieldsEvent()
        {
            var even = CreateEvenIncome(100000)
                .Concat(new[] { new LoopApplication { a = "id", annual_inc = "660000", addr_state = "OK", emp_length = "10 year(s)" } })
                .ToList();
            var actual = _sut.Decide(even);
            CollectionAssert.IsNotEmpty(actual);
        }

        private static IEnumerable<LoopApplication> CreateEvenIncome(int limit)
        {
            var statesData = new[]
            {
                new { name="OH", min = 10000, max = 30000 },
                new { name="MI", min = 10000, max = 20000 },
                new { name="NY", min = 80000, max = 100000 },
                new { name="CA", min = 180000, max = 210000 },
                new { name="TN", min = 70000, max = 900000 },
                new { name="NV", min = 20000, max = 40000 },
                new { name="OK", min = 30000, max = 50000 }
            };
            var rnd = new Random();
            foreach(var i in Enumerable.Range(0,limit))
            {
                var state = statesData.RandomItem(rnd);
                var empLength = rnd.Next(1, 11);
                yield return new LoopApplication
                {
                    a = $"{i}",
                    // let's  pretend it's linear :)
                    annual_inc =$"{rnd.Next(state.min, state.max) * empLength}",
                    addr_state = state.name,
                    emp_length = $"{empLength} year(s)"
                };
            }
        }
    }
}
