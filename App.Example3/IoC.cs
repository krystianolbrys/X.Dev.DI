using System;
using System.IO;
using System.Linq;
using System.Reflection;
using App.Example3.CQRS.Decorators;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using X.Logger;
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

        public static void ConfigureHandlersWithDecorator()
        {
            var allTypes = Assembly.GetExecutingAssembly().GetTypes().Cast<TypeInfo>();

            var handlerTypes =
                    allTypes
                        .Where(t => !t.IsGenericTypeDefinition)
                        .Where(t => t.ImplementedInterfaces.All(i => i.IsGenericType))
                        .Where(t => t.ImplementedInterfaces.Any(i =>
                            i.GetGenericTypeDefinition().Equals(typeof(IHandler<,>))))
                        .ToList();

            var handlerTypesToDecorate =
                    handlerTypes
                        .SelectMany(t => t.ImplementedInterfaces)
                        .ToList();


            Container.Register(
                Component.For(handlerTypesToDecorate)
                .ImplementedBy(typeof(LoggingDecorator<,>))
                .LifestylePerThread());

            Container.Register(
                Classes.From(handlerTypes)
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

            ConfigureLogging();
        }

        private static void ConfigureLogging()
        {
            ILogger logger = new FileLogger(Path.Combine(Environment.CurrentDirectory, "log.txt"));

            Container.Register(
                Component.For<ILogger>()
                .Instance(logger)
                .LifestyleSingleton());
        }

        public static T Resolve<T>() => Container.Kernel.Resolve<T>();
    }
}
