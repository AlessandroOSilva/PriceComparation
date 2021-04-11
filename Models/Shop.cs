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
        public ICollection<ProductShop> Products { get; set; } = new List<ProductShop>();

        public Shop()
        {
        }

        public Shop(int id, string name, Address address)
        {
            ShopId = id;
            Name = name;
            Address = address;
        }

        public void AddProduct(ProductShop productShop)
        {
            Products.Add(productShop);
        }

        public List<ProductShop> ListProduct()
        {
            return Products.ToList();
        }

        public void RemoveProduct(ProductShop p)
        {
            Products.Remove(p);
        }
    }
}
