using App.Example3.CQRS.Requests;
using X.Mediator;

namespace App.Example3.CQRS.RequestHandlers
{
    public class MultiplyTwoNumbersRequestHandler : IHandler<MultiplyTwoNumbersRequest, int>
    {
        public int Handle(MultiplyTwoNumbersRequest request)
        {
            var result = request.A * request.B;
            return result;
        }
    }
}
