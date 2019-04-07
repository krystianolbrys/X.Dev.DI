using System;
using App.Example3.CQRS.Requests;
using X.Mediator;

namespace App.Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.ConfigureHandlersBasic();

            var mediator = IoC.Resolve<IMediator>();


            var request = new AddTwoNumbersRequest(3, 4);
            var result = mediator.Send(request);

            Console.WriteLine(result);
        }
    }
}
