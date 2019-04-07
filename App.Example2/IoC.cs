using System;
using System.IO;
using System.Reflection;
using App.Example2.Implementation;
using App.Example2.Interceptors;
using App.Example2.Interfaces;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using X.Logger;

namespace App.Example2
{
    public class IoC
    {
        private static readonly WindsorContainer Container = new WindsorContainer();

        public static void Configure()
        {
            var logger = new FileLogger(Path.Combine(Environment.CurrentDirectory, "log.txt"));

            Container.Register(
                Component.For<ILogger>()
                .Instance(logger)
                .LifestyleSingleton());

            Container.Register(
                Classes.FromAssembly(Assembly.GetCallingAssembly())
                .BasedOn<IInterceptor>()
                .WithService
                .FromInterface());

            Container.Register(
                Component.For<IService>()
                .ImplementedBy<Service>()
                .Interceptors<LoggingInterceptor>()
                .Interceptors<TimeMetterInterceptor>()
                .LifestylePerThread());
        }

        public static T Resolve<T>() => Container.Kernel.Resolve<T>();
    }
}
