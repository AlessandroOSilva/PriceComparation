using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        
        [ForeignKey("Id")]
        public Shop Shop { get; set; }
        

        public Address()
        {
        }

        public Address(int id, string state, string city, string district, string street, Shop shop)
        {
            Id = id;
            State = state;
            City = city;
            District = district;
            Street = street;
            Shop = shop;
        }
    }
}
