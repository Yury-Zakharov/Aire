using Aire.Domain;
using Aire.Services.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Aire.Services
{
    [ServiceBehavior(UseSynchronizationContext = true, InstanceContextMode = InstanceContextMode.Single)]
    public sealed class LoopService : ILoopService
    {
        private readonly IDataProvider _dataProvider;
        private readonly IGovernor _governor;

        public LoopService(IDataProvider dataProvider, IGovernor governor)
        {
            _dataProvider = dataProvider;
            _governor = governor;
        }

        void ILoopService.AddApplication(LoopApplication application)
        {
            _dataProvider.AddApplication(application);
        }

        IEnumerable<LoopEvent> ILoopService.GetEvents()
        {
            var applications = _dataProvider.GetApplications();
            return _governor.Decide(applications);            
        }
    }
}
