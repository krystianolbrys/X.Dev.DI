using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Web.Example.CQRS.Decorators;
using Web.Example.Interfaces;
using Web.Example.Services;
using X.Logger;
using X.Mediator;

namespace Web.Example
{
    public class IoC
    {
        public static readonly WindsorContainer Container = new WindsorContainer();

        public static void ConfigureServices()
        {
            Container.Register(
                Component
                .For<IService, Service>()
                .LifestyleScoped());
        }

        public static void ConfigureHandlersWithDecorator()
        {
            ConfigureInterceptor();

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
                .LifestyleScoped());

            Container.Register(
                Classes.From(handlerTypes)
                .BasedOn(typeof(IHandler<,>))
                .WithService.FirstInterface()
                .Configure(conf => conf.Interceptors<LoggingInterceptor>())
                .LifestyleScoped());

            Container.Register(
                Component
                .For<IMediator, Mediator>()
                .LifestyleScoped());

            Container.Register(
                Component
                .For<ServiceFactory>()
                .UsingFactoryMethod<ServiceFactory>(kernel => type => Container.Kernel.Resolve(type))
                .LifestyleScoped());

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

        private static void ConfigureInterceptor()
        {
            Container.Register(
                Classes.FromAssembly(Assembly.GetCallingAssembly())
                .BasedOn<IInterceptor>()
                .WithService.FirstInterface());
        }
    }
}
