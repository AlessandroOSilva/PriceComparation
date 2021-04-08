    using System.Collections.Generic;

namespace PricesComparation.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public ICollection<Product> Products { get; set; }

        public Shop(int id, string name, Address address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public void AddProduct(Product p)
        {
            Products.Add(p);
        }

        public void RemoveProduct(Product p)
        {
            Products.Remove(p);
        }
    }
}
