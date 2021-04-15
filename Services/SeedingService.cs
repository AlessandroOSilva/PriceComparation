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
        private readonly PricesComparationContext _context;

        public SeedingService(PricesComparationContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Shop.Any()||
                _context.Brand.Any()||
                _context.Product.Any()||
                _context.ProductShops.Any()||
                _context.PriceRecords.Any())
            {
                return;
            }

            Address a1 = new(1, "Goiás", "Aparecida de Goiânia", "Nova Olinda", "Av. Santana");
            Address a2 = new(2, "Goiás", "Aparecida de Goiânia", "Parque Itamarati", "Av. Maria Lopes");
            

            Shop s1 = new(3, "Cristo Rei 2", a1);
            Shop s2 = new(4, "Armazem Castro", a2);
            

            Brand b1 = new(5, "Sadia");
            Brand b2 = new(6, "Perdigão");
            

            Product p1 = new(7, "Coxa e sobre-coxa","img1", "Carne", b1);
            Product p2 = new(8, "Coxa e sobre-coxa","img2", "Carne", b1);

            ProductShop ps1 = new(1, p1, s1, 11.00, DateTime.Today);
            ProductShop ps2 = new(2, p2, s1, 11.00, DateTime.Today);

            ProductShop ps3 = new(3,p1, s2, 12.00, DateTime.Today);
            ProductShop ps4 = new(4,p2, s2, 12.00, DateTime.Today);

            PriceRecord pr1 = new PriceRecord(1, ps1, ps1.Price, ps1.PriceDate);
            PriceRecord pr2 = new PriceRecord(2, ps2, ps2.Price, ps2.PriceDate);
            PriceRecord pr3 = new PriceRecord(3, ps3, ps3.Price, ps3.PriceDate);
            PriceRecord pr4 = new PriceRecord(4, ps4, ps4.Price, ps4.PriceDate);

            ps1.AddRecord(pr1);
            ps1.AddRecord(pr2);
            ps1.AddRecord(pr3);
            ps1.AddRecord(pr4);

            b1.InsertProduct(p1);
            b2.InsertProduct(p2);

            b1.InsertProduct(p1);
            b2.InsertProduct(p2);

            s1.AddProduct(ps1);
            s1.AddProduct(ps2);

            s2.AddProduct(ps3);
            s2.AddProduct(ps4);

            _context.ProductShops.AddRange(ps1,ps2, ps3, ps4);
            _context.PriceRecords.AddRange(pr1, pr2, pr3, pr4);
            _context.Shop.AddRange(s1, s2);
            _context.Brand.AddRange(b1, b2);
            _context.Product.AddRange(p1, p2);

            _context.SaveChanges();
        }
    }
}
