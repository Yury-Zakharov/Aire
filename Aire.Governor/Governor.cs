using System;
using System.Collections.Generic;
using Aire.Domain;
using System.Linq;

namespace Aire.Governor
{
    public sealed class Governor : IGovernor
    {
        private readonly IEnumerable<IDecisionProvider> _providers;

        public Governor(IEnumerable<IDecisionProvider> providers)
        {
            _providers = providers ?? Enumerable.Empty<IDecisionProvider>();
        }

        IEnumerable<LoopEvent> IGovernor.Decide(IEnumerable<LoopApplication> applications) =>
            _providers.SelectMany(p => p.Decide(applications));
        
    }
}
