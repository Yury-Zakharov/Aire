using Aire.Domain;
using Autofac;
using System.Data.Entity;

namespace Aire.Data.Infrastructure
{
    public class DataModule : Module
    {
        public DataModule()
        {
            // not the best place for this, probably...
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LoopModel>());
        }

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
