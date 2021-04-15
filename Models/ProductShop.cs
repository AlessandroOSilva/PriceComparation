using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Models
{
    public class ProductShop
    {
        [Key]
        public int ProductShopId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }
        public double Price { get; set; }
        public DateTime PriceDate { get; set; }
        public ICollection<PriceRecord> Records { get; set; } = new List<PriceRecord>();

        public ProductShop()
        {
        }

        public ProductShop(int productShopId, Product product, Shop shop, double price, DateTime priceDate)
        {
            ProductShopId = productShopId;
            Product = product;
            Shop = shop;
            Price = price;
            PriceDate = priceDate;
        }

        public void AddRecord(PriceRecord pr)
        {
            Records.Add(pr);
        }

        public void ChangePrice(double valor, DateTime date)
        {
            PriceDate = date;
            Price = valor;
        }

        public List<PriceRecord> AllRecordProduct(long id)
        { 
             return Records.TakeWhile(p => p.ProductShop.ProductShopId.Equals(id)).ToList();
        }
    }
}
