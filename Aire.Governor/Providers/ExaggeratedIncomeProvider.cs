using Aire.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Aire.Governor.Providers
{
    public sealed class ExaggeratedIncomeProvider : IDecisionProvider
    {
        IEnumerable<LoopEvent> IDecisionProvider.Decide(IEnumerable<LoopApplication> applications)
        {
            var aboveAverage = applications.GroupBy(
                ap => new
                {
                    ap.addr_state,
                    ap.emp_length
                })
                .SelectMany(ap => ap.Where(p => 
                (p.AnnualIncome - ap.Average(aps => aps.AnnualIncome)) / p.AnnualIncome > 0.618m
                ));
            foreach (var application in aboveAverage)
            {
                yield return new LoopEvent { Category = Events.ExaggeratedIncome, ApplicationId = application.id };
            }
        }
    }
}
