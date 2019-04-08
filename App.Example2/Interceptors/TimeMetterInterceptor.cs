using System.Diagnostics;
using System.Linq;
using App.Example2.Attributes;
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
            if (invocation.MethodInvocationTarget.CustomAttributes.Any(t => t.AttributeType.Equals(typeof(TimeMetterAttribute))))
            {
                var stopwatch = Stopwatch.StartNew();
                invocation.Proceed();
                _logger.Log($"{invocation.Method.Name} -> {stopwatch.ElapsedTicks} ticks");
                return;
            }

            invocation.Proceed();
        }
    }
}
