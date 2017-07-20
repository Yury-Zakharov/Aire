using System;
using Aire.Governor.Providers;
using NUnit.Framework;
using System.Collections.Generic;
using Aire.Domain;
using System.Linq;
using System.Globalization;

namespace Aire.GovernorTests.Providers
{
    [TestFixture]
    public class NewGeoProviderTests : ProviderTestBase<NewGeoProvider>
    {

        [Test]
        public void NewStatesYieldEvents()
        {
            var even = CreateEvenDistribution(100000).ToList();
            var actual = _sut.Decide(even);
            // 7 is exact number of distinct states 
            // in the sample set.
            Assert.AreEqual(7, actual.Count());
        }

        private static IEnumerable<LoopApplication> CreateEvenDistribution(int limit)
        {
            var statesData = new[]
            {
                new { name="OH"},
                new { name="MI"},
                new { name="NY"},
                new { name="CA"},
                new { name="TN"},
                new { name="NV"},
                new { name="OK"}
            };
            var months = DateTimeFormatInfo.InvariantInfo.AbbreviatedMonthNames.Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();
            var rnd = new Random();
            foreach (var i in Enumerable.Range(0, limit))
            {
                var state = statesData.RandomItem(rnd);
                yield return new LoopApplication
                {
                    a = $"{i}",
                    addr_state = state.name,
                    issue_d = $"{months.RandomItem(rnd)}-{rnd.Next(10, 20)}"
                };
            }
        }
    }
}
