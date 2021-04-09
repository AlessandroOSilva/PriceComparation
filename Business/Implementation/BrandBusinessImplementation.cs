using PricesComparation.Models;
using PricesComparation.Repositories;
using System.Collections.Generic;

namespace PricesComparation.Business.Implementation
{
    public class BrandBusinessImplementation : IBrandBusiness
    {
        private readonly IBrandRepository _repository;

        public BrandBusinessImplementation(IBrandRepository repository)
        {
            _repository = repository;
        }

        public Brand Create(Brand brand)
        {
            return _repository.Create(brand);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Brand FinById(int id)
        {
            return _repository.FinById(id);
        }

        public List<Brand> FindAll()
        {
            return _repository.FindAll();
        }

        public Brand Update(Brand brand)
        {
            return _repository.Update(brand);
        }
    }
}
