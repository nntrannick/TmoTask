using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMO.DataAccess.Entities
{
    public class Order
    {
        public required string Seller { get; set; }
        public required string Product { get; set; }
        public  decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public required string Branch { get; set; }
    }
}
