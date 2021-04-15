using PricesComparation.Repositories.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace PricesComparation.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Typed { get; set; }
        [ForeignKey("BrandId")]
        [DataMember(EmitDefaultValue = true)]
        public Brand Brand { get; set; }
        public Product()
        {
        }
        public Product(int id, string name,string image, string typed, Brand brand)
        {
            Id = id;
            Name = name;
            Image = image;
            Typed = typed;
            Brand = brand;
        }
    }
}
