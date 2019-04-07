using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using X.Logger;
using X.Mediator;

namespace Web.Example.CQRS.Decorators
{
    public class LoggingDecorator<TRequest, TResponse> : IHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger _logger;
        private readonly IHandler<TRequest, TResponse> _inner;

        public LoggingDecorator(ILogger logger, IHandler<TRequest, TResponse> inner)
        {
            _logger = logger;
            _inner = inner;
        }

        public TResponse Handle(TRequest request)
        {
            var result = _inner.Handle(request);

            _logger.Log($"{_inner.GetType().Name} -> Request: {JsonConvert.SerializeObject(request)} Result: {JsonConvert.SerializeObject(result)}");

            return result;
        }
    }
}
