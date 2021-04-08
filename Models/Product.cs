using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Typed { get; set; }
        [ForeignKey("Id")]
        public Brand Brand { get; set; }
        public double Price { get; set; }
        [ForeignKey("Id")]
        public Shop Shop { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, string typed, Brand brand, double price)
        {
            Id = id;
            Name = name;
            Typed = typed;
            Brand = brand;
            Price = price;
        }

    }
}
