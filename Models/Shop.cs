using Newtonsoft.Json;
using PricesComparation.Repositories.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PricesComparation.Models
{
    [JsonObject(IsReference = true)]
    public class Shop : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey("AddressId")]
        [JsonInclude]
        [DataMember(EmitDefaultValue = true)]
        public Address Address { get; set; }
        [JsonInclude]
        [DataMember(EmitDefaultValue =true)]
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
