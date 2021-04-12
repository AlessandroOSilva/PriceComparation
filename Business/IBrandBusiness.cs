using PricesComparation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Business
{
    public interface IBrandBusiness
    {
        Brand Create(Brand brand);
        Brand FindById(long id);
        Brand Update(Brand brand);
        List<Brand> FindAll();
        void Delete(long id);
    }
}
