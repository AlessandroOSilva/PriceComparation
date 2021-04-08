﻿using PricesComparation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Repositories
{
    public interface IProductRepository
    {
        Product Create(Product product);
        Product FindById(long id);
        Product Update(Product product);
        List<Product> FindAll();
        void Delete(long id);
        bool Exists(long id);
    }
}
