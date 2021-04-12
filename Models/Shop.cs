using PricesComparation.Repositories.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PricesComparation.Models
{
    public class Shop : BaseEntity
    {
        public string Name { get; set; }
        
        [ForeignKey("AddressId")]
        public Address Address { get; set; }
        public ICollection<ProductShop> Products { get; set; } = new List<ProductShop>();

        public Shop()
        {
        }

        public Shop(int id, string name, Address address)
        {
            Id = id;
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
