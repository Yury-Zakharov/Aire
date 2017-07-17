using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aire.Domain
{
   public interface IGovernor
    {
        IEnumerable<LoopEvent> Decide(IEnumerable<LoopApplication> applications);
    }
}
