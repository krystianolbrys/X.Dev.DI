using System;

namespace X.Mediator
{
    public class Mediator : IMediator
    {
        private readonly ServiceFactory _factory;

        public Mediator(ServiceFactory factory)
        {
            _factory = factory;
        }

        public TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            var wrapper =
                (IWrapper<TResponse>)Activator
                .CreateInstance(typeof(Wrapper<,>).MakeGenericType(request.GetType(), typeof(TResponse)));

            return wrapper.Handle(request, _factory);
        }
    }

    public interface IWrapper<TResponse>
    {
        TResponse Handle(IRequest<TResponse> request, ServiceFactory factory);
    }

    public class Wrapper<TRequest, TResponse> : IWrapper<TResponse>
        where TRequest : IRequest<TResponse>
    {
        public TResponse Handle(IRequest<TResponse> request, ServiceFactory factory)
        {
            var handlerType = typeof(IHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var handler = (IHandler<TRequest, TResponse>)factory(handlerType);

            return handler.Handle((TRequest)request);
        }
    }
}
