using System;
using App.Example1.Contracts;

namespace App.Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.Configure();

            IService service = IoC.Resolve<IService>();

            var userId = service.GetRandomUserId();

            Console.WriteLine(userId);
        }
    }
}
