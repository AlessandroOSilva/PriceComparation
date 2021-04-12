using Microsoft.EntityFrameworkCore;
using PricesComparation.Models.Context;
using PricesComparation.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Repositories.Generics
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly PricesComparationContext _context;
        private DbSet<T> dataset;
        public GenericRepository(PricesComparationContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T t)
        {
            try
            {
                dataset.Add(t);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return t;
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return dataset.Any(x => x.Id.Equals(id));
        }

        public T FindById(long id)
        {
            return dataset.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T Update(T t)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(t.Id));
            if (result != null)
            {
                try
                {
                    dataset.Update(result);
                    _context.SaveChanges();
                    return result;
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
    }
}

