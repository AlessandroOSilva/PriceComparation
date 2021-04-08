using PricesComparation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Repositories
{
    public interface IBrandRepository
    {
        Brand Create(Brand brand);
        Brand FinById(int id);
        Brand Update(Brand brand);
        List<Brand> FindAll();
        void Delete(long id);
        bool Exists(long id);
    }
}
