using Web.Example.CQRS.Requests;
using Web.Example.Interfaces;
using X.Mediator;

namespace Web.Example.Services
{
    public class Service : IService
    {
        private readonly IMediator _mediator;

        public Service(IMediator mediator)
        {
            _mediator = mediator;
        }

        public int CalculateSum(int a, int b) =>
            _mediator.Send(new AddTwoNumbersRequest(a, b));

        public int ExceptionMethod() =>
            _mediator.Send(new GenerateErrorRequest());
    }
}
