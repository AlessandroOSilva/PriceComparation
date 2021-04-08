﻿using PricesComparation.Models;
using PricesComparation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Business.Implementation
{
    public class ShopBusinessImplementation : IShopBusiness
    {
        private readonly IShopRepository _repository;

        public ShopBusinessImplementation(IShopRepository repository)
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
