using System.Collections.Generic;

namespace Aire.Domain
{
    public interface IDataProvider
    {
        void AddApplication(LoopApplication application);
        IEnumerable<LoopApplication> GetApplications();
    }
}
