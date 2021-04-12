using PricesComparation.Models;
using PricesComparation.Repositories;
using PricesComparation.Repositories.Generics;
using System.Collections.Generic;

namespace PricesComparation.Business.Implementation
{
    public class BrandBusinessImplementation : IBrandBusiness
    {
        private readonly IGenericRepository<Brand> _repository;

        public BrandBusinessImplementation(IGenericRepository<Brand> repository)
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

        public Brand FindById(long id)
        {
            return _repository.FindById(id);
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
