    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PricesComparation.Models
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }
        public string Name { get; set; }
        
        [ForeignKey("AdressId")]
        public Address Address { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public Shop()
        {
        }

        public Shop(int id, string name, Address address)
        {
            ShopId = id;
            Name = name;
            Address = address;
        }

        public void AddProduct(Product p, double price)
        {
            p.Shop = this;
            p.Price = price;
            Products.Add(p);
        }

        public List<Product> ListProduct()
        {
            return Products.ToList();
        }

        public void RemoveProduct(Product p)
        {
            Products.Remove(p);
        }
    }
}
