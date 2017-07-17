using Aire.Domain;
using Autofac;

namespace Aire.Data.Infrastructure
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(ThisAssembly)
            //    .Where(type => type.Name.EndsWith("DataProvider"))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();

            builder.RegisterType<SqlLocalDataProvider>().As<IDataProvider>().InstancePerLifetimeScope();
        }
    }
}
