using PricesComparation.Models;
using PricesComparation.Repositories;
using System;
using System.Collections.Generic;

namespace PricesComparation.Business.Implementation
{
    public class ProductBusinesImplementation : IProductBusiness
    {
        private readonly IProductRepository _repository;

        public ProductBusinesImplementation(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product Create(Product product)
        {
            return _repository.Create(product);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Product> FindAll()
        {
            return _repository.FindAll();
        }

        public Product FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Product Update(Product product)
        {
            return _repository.Update(product);
        }
    }
}
