using Aire.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Aire.Governor.Providers
{
    public sealed class DummyProvider : IDecisionProvider
    {
        IEnumerable<LoopEvent> IDecisionProvider.Decide(IEnumerable<LoopApplication> applications)
        {
            foreach (var application in applications.Where(p=>string.IsNullOrWhiteSpace(p.id)))
            {
                yield return new LoopEvent { Category = application.addr_state, ApplicationId = application.id };
            }
        }
    }
}
