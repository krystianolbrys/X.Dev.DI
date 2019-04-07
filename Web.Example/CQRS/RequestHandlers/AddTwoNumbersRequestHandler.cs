using Web.Example.CQRS.Requests;
using X.Mediator;

namespace Web.Example.CQRS.RequestHandlers
{
    public class AddTwoNumbersRequestHandler : IHandler<AddTwoNumbersRequest, int>
    {
        public int Handle(AddTwoNumbersRequest request)
        {
            var result = request.A + request.B;
            return result;
        }
    }
}
