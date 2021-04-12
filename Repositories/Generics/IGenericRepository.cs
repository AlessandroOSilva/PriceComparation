using PricesComparation.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Repositories.Generics
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Create(T t);
        T FindById(long id);
        T Update(T t);
        List<T> FindAll();
        void Delete(long id);
        bool Exists(long id);
    }
}
