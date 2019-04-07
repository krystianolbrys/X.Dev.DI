using System.Reflection;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using X.Mediator;

namespace App.Example3
{
    public class IoC
    {
        private static readonly WindsorContainer Container = new WindsorContainer();

        public static void ConfigureHandlersBasic()
        {
            Container.Register(
                Classes.FromAssembly(Assembly.GetExecutingAssembly())
                .BasedOn(typeof(IHandler<,>))
                .WithService.FirstInterface()
                .LifestylePerThread());

            Container.Register(
                Component
                .For<IMediator, Mediator>()
                .LifestylePerThread());

            Container.Register(
                Component
                .For<ServiceFactory>()
                .UsingFactoryMethod<ServiceFactory>(kernel => type => Container.Kernel.Resolve(type))
                .LifestylePerThread());
        }

        public static T Resolve<T>() => Container.Kernel.Resolve<T>();
    }
}
