using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Models
{
    public class Address
    {
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public Shop Shop { get; set; }
        public int ShopId { get; set; }

        public Address(string state, string city, string district, string street, Shop shop)
        {
            State = state;
            City = city;
            District = district;
            Street = street;
            Shop = shop;
        }
    }
}
