using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace Aire.Services.Infrastructure
{
    public sealed class ServiceRunner : IServiceRunner
    {
        private readonly ILoopService _loopSeervice;
        private IList<ServiceHost> _serviceHosts;

        public ServiceRunner(ILoopService loopSeervice)
        {
            _loopSeervice = loopSeervice;
        }

        public void Start()
        {
            _serviceHosts?.ToList().ForEach(host => host.Close());
            _serviceHosts = new List<ServiceHost>
            {
                new WebServiceHost(_loopSeervice)
            };
            var exceptionHandler = new WcfExceptionHandler();
            ExceptionHandler.TransportExceptionHandler = exceptionHandler;
            ExceptionHandler.AsynchronousThreadExceptionHandler = exceptionHandler;
            _serviceHosts.ToList().ForEach(host =>
            {
                host.Faulted += OnServicesFaulted;
                host.Open();
                Console.WriteLine($"Service {host.Description.Name} is running");
            });
            Console.WriteLine("All services hosts are running");
        }

        public void Stop()
        {
            if (_serviceHosts != null)
            {
                _serviceHosts.ToList().ForEach(host =>
                {
                    try
                    {
                        host.Close();
                        host.Faulted -= OnServicesFaulted;
                    }
                    catch(Exception exception)
                    {
                        Console.WriteLine($"Exception while shutting down the servie: {exception.Message}");
                    }
                });
                _serviceHosts.Clear();
            }
        }

        private void OnServicesFaulted(object sender, EventArgs e)
        {

            Console.WriteLine("Service in fault state, perform investigation");
        }
    }
}
