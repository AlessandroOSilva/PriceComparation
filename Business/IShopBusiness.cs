using PricesComparation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Business
{
    interface IShopBusiness
    {
        Shop Create(Shop shop);
        Shop FindById(long id);
        Shop Update(Shop shop);
        List<Shop> FindAll();
        void Delete(long id);
    }
}
