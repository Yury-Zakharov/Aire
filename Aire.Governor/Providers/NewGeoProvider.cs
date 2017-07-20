using Aire.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aire.Governor.Providers
{
    public sealed class NewGeoProvider : IDecisionProvider
    {
        IEnumerable<LoopEvent> IDecisionProvider.Decide(IEnumerable<LoopApplication> applications)
        {
            // Group by location and take first application with the earliest date.
            var firstComers = applications.GroupBy(ap => ap.addr_state)
                .Select(g => g.Where(p => p.IssueDate == g.Min(m => m.IssueDate)).OrderBy(o => o.a).FirstOrDefault());
            foreach (var application in firstComers)
            {
                yield return new LoopEvent { Category = Events.NewGeo, ApplicationId = application.a };
            }
        }
    }
}
