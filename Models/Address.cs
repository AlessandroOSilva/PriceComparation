using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Models
{
    [JsonObject(IsReference = true)]
    public class Address
    {
        [Key]
        public int AdressId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
              

        public Address()
        {
        }

        public Address(int id, string state, string city, string district, string street)
        {
            AdressId = id;
            State = state;
            City = city;
            District = district;
            Street = street;
        }
    }
}
