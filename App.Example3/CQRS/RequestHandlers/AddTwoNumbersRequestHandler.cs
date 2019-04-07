using App.Example3.CQRS.Requests;
using X.Mediator;

namespace App.Example3.CQRS.RequestHandlers
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
