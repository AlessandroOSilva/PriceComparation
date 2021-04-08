using PricesComparation.Models;
using PricesComparation.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Repositories.Implementation
{
    public class BrandRepositoryImplementation : IBrandRepository
    {
        private readonly PricesComparationContext _context;

        public BrandRepositoryImplementation(PricesComparationContext context)
        {
            _context = context;
        }

        public Brand Create(Brand brand)
        {
            try
            {
                _context.Add(brand);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return brand;
        }

        public void Delete(long id)
        {
            try
            {
                if (Exists(id))
                {
                    _context.Remove(id);
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool Exists(long id)
        {
            return _context.Brand.Any(b => b.Id.Equals(id));
        }

        public Brand FinById(int id)
        {
            return _context.Brand.FirstOrDefault(b => b.Id.Equals(id));
        }

        public List<Brand> FindAll()
        {
            return _context.Brand.ToList();
        }

        public Brand Update(Brand brand)
        {
            if (!Exists(brand.Id)) return null;
            var result = _context.Brand.SingleOrDefault(p => p.Id.Equals(brand.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(brand);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return brand;
        }
    }
}
