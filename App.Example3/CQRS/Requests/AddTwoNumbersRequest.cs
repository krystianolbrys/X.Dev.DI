using X.Mediator;

namespace App.Example3.CQRS.Requests
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
