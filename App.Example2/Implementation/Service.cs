using System;
using App.Example2.Interfaces;

namespace App.Example2.Implementation
{
    public class Service : IService
    {
        public int GetResponseNoException() => 1337;

        public int GetResponseWithException() =>
            throw new ArgumentNullException("brak elementu w bazie");
    }
}
