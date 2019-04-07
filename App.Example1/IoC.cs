using App.Example1.Contracts;
using App.Example1.Infrastructure.Repositories;
using App.Example1.Infrastructure.Services;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace App.Example1
{
    public class IoC
    {
        private static readonly WindsorContainer Container = new WindsorContainer();

        public static void Configure()
        {
            Container.Register(
                Component.For<IRepository>()
                .ImplementedBy<Repository>()
                .LifestylePerThread());

            Container.Register(
                Component.For<IService>()
                .ImplementedBy<Service>()
                .LifestylePerThread());
        }

        public static T Resolve<T>() => Container.Kernel.Resolve<T>();
    }
}
