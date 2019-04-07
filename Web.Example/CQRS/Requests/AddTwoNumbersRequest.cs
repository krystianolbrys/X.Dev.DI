using X.Mediator;

namespace Web.Example.CQRS.Requests
{
    public class AddTwoNumbersRequest : IRequest<int>
    {
        public AddTwoNumbersRequest(int a, int b)
        {
            A = a;
            B = b;
        }

        public int A { get; }
        public int B { get; }
    }
}
