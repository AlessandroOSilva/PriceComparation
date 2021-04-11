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

        public PriceRecord()
        {
        }

        public PriceRecord(int recordId, ProductShop productShop)
        {
            RecordId = recordId;
            ProductShop = productShop;
        }
    }
}
