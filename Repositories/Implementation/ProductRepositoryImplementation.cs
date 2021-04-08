using PricesComparation.Models;
using PricesComparation.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Repositories.Implementation
{
    public class ProductRepositoryImplementation : IProductRepository
    {
        private readonly PricesComparationContext _context;

        public ProductRepositoryImplementation(PricesComparationContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {
            try
            {
                _context.Add(product);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return product;
        }

        public void Delete(long id)
        {
            try
            {
                if (Exists(id))
                {
                    _context.Remove(id);
                }
            }
            catch
            {
                throw;
            }
        }

        public bool Exists(long id)
        {
            return _context.Product.Any(p => p.Id.Equals(id));
        }

        public List<Product> FindAll()
        {
            return _context.Product.ToList() ;
        }

        public Product FindById(long id)
        {
            return _context.Product.FirstOrDefault(x => x.Id.Equals(id));
        }

        public Product Update(Product product)
        {
            if(!Exists(product.Id)) return null;
            var result = _context.Product.SingleOrDefault(p => p.Id.Equals(product.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(product);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return product;
        }
    }
}
