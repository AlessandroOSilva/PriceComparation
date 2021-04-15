using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PricesComparation.Models
{
    public class PriceRecord
    {
        [Key]
        public int RecordId { get; set; }
        [ForeignKey("ProductShopId")]
        public virtual ProductShop ProductShop { get; set; }
        public double Price { get; set; }
        public DateTime PriceDate { get; set; }

        public PriceRecord()
        {
        }

        public PriceRecord(int recordId, ProductShop productShop, double price, DateTime priceDate)
        {
            RecordId = recordId;
            ProductShop = productShop;
            Price = price;
            PriceDate = priceDate;
        }

        public void InsertProductRecord()
        {
            Price = ProductShop.Price;
            PriceDate = ProductShop.PriceDate;
        }
    }
}
