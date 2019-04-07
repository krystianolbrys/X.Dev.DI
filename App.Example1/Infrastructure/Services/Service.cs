using App.Example1.Contracts;

namespace App.Example1.Infrastructure.Services
{
    public class Service : IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public int GetRandomUserId()
        {
            var result = _repository.GetRandomUserId();

            return result;
        }
    }
}
