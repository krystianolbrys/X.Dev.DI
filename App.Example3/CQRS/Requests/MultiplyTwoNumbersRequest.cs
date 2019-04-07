using X.Mediator;

namespace App.Example3.CQRS.Requests
{
    public class MultiplyTwoNumbersRequest : IRequest<int>
    {
        public MultiplyTwoNumbersRequest(int a, int b)
        {
            A = a;
            B = b;
        }

        public int A { get; }
        public int B { get; }
    }
}
