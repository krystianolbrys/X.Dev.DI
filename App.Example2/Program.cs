using App.Example2.Interfaces;

namespace App.Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.Configure();

            var myService = IoC.Resolve<IService>();

            var result1 = myService.GetResponseNoExceptionWithTimeMetter();
            var result2 = myService.GetResponseNoExceptionWithoutTimeMetter();
            var result3 = myService.GetResponseWithException();
        }
    }
}
