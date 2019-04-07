using System.Diagnostics;
using Castle.DynamicProxy;
using X.Logger;

namespace App.Example2.Interceptors
{
    public class TimeMetterInterceptor : IInterceptor
    {
        private readonly ILogger _logger;

        public TimeMetterInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            var stopwatch = Stopwatch.StartNew();
            invocation.Proceed();
            _logger.Log($"{invocation.Method.Name} -> {stopwatch.ElapsedTicks} ticks");
        }
    }
}
