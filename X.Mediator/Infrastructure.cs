using System;

namespace X.Mediator
{
    public interface IRequest<TResponse> { }

    public interface IHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        TResponse Handle(TRequest request);
    }

    public interface IMediator
    {
        TResponse Send<TResponse>(IRequest<TResponse> request);
    }

    public delegate object ServiceFactory(Type type);
}
