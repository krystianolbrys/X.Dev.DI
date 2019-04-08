using System;
using App.Example2.Attributes;
using App.Example2.Interfaces;

namespace App.Example2.Implementation
{
    public class Service : IService
    {
        [TimeMetter]
        public int GetResponseNoExceptionWithTimeMetter() => 1337;

        public int GetResponseNoExceptionWithoutTimeMetter() => 7331;

        public int GetResponseWithException() =>
            throw new ArgumentNullException("brak elementu w bazie");
    }
}
