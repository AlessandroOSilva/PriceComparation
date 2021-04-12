using PricesComparation.Repositories.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Typed { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, string typed, Brand brand)
        {
            Id = id;
            Name = name;
            Typed = typed;
            Brand = brand;  
        }
    }
}
