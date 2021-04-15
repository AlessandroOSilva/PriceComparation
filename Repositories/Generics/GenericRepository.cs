using Microsoft.EntityFrameworkCore;
using PricesComparation.Models.Context;
using PricesComparation.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Repositories.Generics
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly PricesComparationContext _context;
        private readonly DbSet<T> dataset;
        public GenericRepository(PricesComparationContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public async Task<T> Create(T t)
        {
            try
            {
                 dataset.Add(t);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
             return t;
        }

        public async Task Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    await _context.SaveChangesAsync();
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

        public async Task<T> FindById(long id)
        {
            return await dataset.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<List<T>> FindAll()
        {
            return await dataset.ToListAsync();
        }

        public async Task<T> Update(T t)
        {
            var result = await dataset.SingleOrDefaultAsync(p => p.Id.Equals(t.Id));
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

