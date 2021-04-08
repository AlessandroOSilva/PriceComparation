using PricesComparation.Models;
using PricesComparation.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Repositories.Implementation
{
    public class ShopRepositoryImplementation : IShopRepository
    {
        private readonly PricesComparationContext _context;

        public ShopRepositoryImplementation(PricesComparationContext context)
        {
            _context = context;
        }

        public Shop Create(Shop shop)
        {
            try
            {
                _context.Add(shop);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return shop;
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
            return _context.Shop.Any(x => x.Id.Equals(id));
        }

        public List<Shop> FindAll()
        {
            return _context.Shop.ToList();
        }

        public Shop FindById(long id)
        {
            return _context.Shop.FirstOrDefault(x => x.Id.Equals(id));
        }

        public Shop Update(Shop shop)
        {
            if (!Exists(shop.Id)) return null;
            var result = _context.Shop.FirstOrDefault(x => x.Id.Equals(shop.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(shop);
                    _context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
            return shop;
        }
    }
}
