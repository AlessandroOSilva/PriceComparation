using PricesComparation.Models;
using PricesComparation.Repositories;
using PricesComparation.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Business.Implementation
{
    public class ShopBusinessImplementation : IShopBusiness
    {
        private readonly IGenericRepository<Shop> _repository;

        public ShopBusinessImplementation(IGenericRepository<Shop> repository)
        {
            _repository = repository;
        }

        public Shop Create(Shop shop)
        {
            return _repository.Create(shop);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Shop> FindAll()
        {
            return _repository.FindAll();
        }

        public Shop FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Shop Update(Shop shop)
        {
            return _repository.Update(shop);
        }
    }
}
