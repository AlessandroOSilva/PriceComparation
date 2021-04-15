using PricesComparation.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Repositories.Generics
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Create(T t);
        Task<T> FindById(long id);
        Task<T> Update(T t);
        Task<List<T>> FindAll();
        Task Delete(long id);
        bool Exists(long id);
    }
}
