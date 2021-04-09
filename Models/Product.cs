using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Typed { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        public double Price { get; set; }
        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, string typed, Brand brand)
        {
            ProductId = id;
            Name = name;
            Typed = typed;
            Brand = brand;  
        }
    }
}
