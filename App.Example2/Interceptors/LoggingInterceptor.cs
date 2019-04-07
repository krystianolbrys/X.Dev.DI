﻿using System;
using Castle.DynamicProxy;
using X.Logger;

namespace App.Example2.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogger _logger;

        public LoggingInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString());
                throw;
            }

        }
    }
}
