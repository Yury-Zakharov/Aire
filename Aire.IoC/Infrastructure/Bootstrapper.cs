using Aire.Data.Infrastructure;
using Aire.Domain.Infrastructure;
using Aire.Governor.Infrastructure;
using Aire.Services.Infrastructure;
using Autofac;
using Autofac.Integration.Wcf;
using System;

namespace Aire.IoC.Infrastructure
{
    public sealed class Bootstrapper
    {
        private static readonly Func<IContainer> Instance = (() =>
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<GovernorModule>();
            builder.RegisterModule<DataModule>();
            builder.RegisterModule<DomainModule>();
            builder.RegisterModule<ServicesModule>();
            var container = builder.Build();
            AutofacHostFactory.Container = container;
            return container;
        });

        private Bootstrapper()
        {
        }

        public static IContainer Container => 
            Instance.Invoke();
        
    }
}
