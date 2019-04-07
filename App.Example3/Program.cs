using System;
using App.Example3.CQRS.Requests;
using X.Mediator;

namespace App.Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.ConfigureHandlersWithDecorator();
            var mediator = IoC.Resolve<IMediator>();


            var request = new AddTwoNumbersRequest(3, 46);
            //var request = new MultiplyTwoNumbersRequest(3, 4);


            var result = mediator.Send(request);
            Console.WriteLine(result);
        }
    }
}
