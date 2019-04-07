using System;
using Web.Example.CQRS.Requests;
using X.Mediator;

namespace Web.Example.CQRS.RequestHandlers
{
    public class GenerateErrorRequestHandler : IHandler<GenerateErrorRequest, int>
    {
        public int Handle(GenerateErrorRequest request)
        {
            throw new ArgumentNullException("testowy null exception");
        }
    }
}
