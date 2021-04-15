using PricesComparation.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace PricesComparation.Models
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public Brand()
        {
        }

        public Brand(int id, string name)
        {
            Id = id;
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
        public List<Product> FindProducts()
        {
            return Products.ToList();
        }
    }
}
