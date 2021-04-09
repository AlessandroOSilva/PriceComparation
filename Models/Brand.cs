using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public Brand()
        {
        }

        public Brand(int id, string name)
        {
            BrandId = id;
            Name = name;
        }

        public void InsertProduct(Product p)
        {
            p.Brand = this;
            Products.Add(p);
        }

        public void RemoveProduct(Product p)
        {
            Products.Remove(p);
        }
        public List<Product> FindAll()
        {
            return Products.ToList();
        }
    }
}
