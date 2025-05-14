using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMO.DataAccess.Entities
{
    public class SellerPerformance
    {
        public required string Month { get; set; }
        public required string Seller { get; set; }
        public int TotalOrder { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
