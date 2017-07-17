using Aire.IoC.Infrastructure;
using Aire.Services.Infrastructure;
using Topshelf;
using Topshelf.Autofac;

namespace Aire.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Bootstrapper.Container;
            HostFactory.Run(c =>
            {
                c.RunAsLocalSystem();
                c.UseAutofacContainer(container);
                c.SetDescription("Aire Loop Service - test implementation.");
                c.SetDisplayName("Aire Loop Service");
                c.SetServiceName("AireLoopService");
                c.EnableServiceRecovery(a => a.RestartService(1));
                // c.UseNLog();

                c.Service<IServiceRunner>(s =>
                {
                    s.ConstructUsingAutofacContainer();
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service =>
                    {
                        service.Stop();
                        container?.Dispose();
                    });
                });
            });
        }
    }
}
