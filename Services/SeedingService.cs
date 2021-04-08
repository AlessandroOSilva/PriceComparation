using PricesComparation.Models;
using PricesComparation.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Services
{
    public class SeedingService
    {
        private PricesComparationContext _context;

        public SeedingService(PricesComparationContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Shop.Any()||
                _context.Brand.Any()||
                _context.Product.Any())
            {
                return;
            }

            Address a1 = new Address(1, "Goiás", "Aparecida de Goiânia", "Nova Olinda", "Av. Santana");
            Address a2 = new Address(2, "Goiás", "Aparecida de Goiânia", "Parque Itamarati", "Av. Maria Lopes");
            

            Shop s1 = new Shop(3, "Cristo Rei 2", a1);
            Shop s2 = new Shop(4, "Armazem Castro", a2);
            _context.Shop.AddRange(s1, s2);

            Brand b1 = new Brand(5, "Sadia");
            Brand b2 = new Brand(6, "Perdigão");
            _context.Brand.AddRange(b1, b2);

            Product p1 = new Product(7, "Coxa e sobre-coxa", "Carne", b1, 12.00);
            Product p2 = new Product(8, "Coxa e sobre-coxa", "Carne", b1, 12.00);
            _context.Product.AddRange(p1, p2);

            s1.AddProduct(p1);
            s1.AddProduct(p2);

            s2.AddProduct(p1);
            s2.AddProduct(p2);

            _context.SaveChanges();
        }
    }
}
