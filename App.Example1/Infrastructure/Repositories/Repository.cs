using System;
using App.Example1.Contracts;

namespace App.Example1.Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        public int GetRandomUserId()
        {
            Random randomGenerator = new Random();
            var result = randomGenerator.Next(10, 99);

            return result;
        }
    }
}
