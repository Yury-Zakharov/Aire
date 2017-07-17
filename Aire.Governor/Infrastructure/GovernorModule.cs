using Aire.Domain;
using Autofac;

namespace Aire.Governor.Infrastructure
{
    public sealed class GovernorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => typeof(IDecisionProvider).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType<Governor>().As<IGovernor>();
        }
    }
}
