using Autofac;

namespace Aire.Services.Infrastructure
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoopService>().As<ILoopService>();
            builder.RegisterType<ServiceRunner>().As<IServiceRunner>();
        }
    }
}
