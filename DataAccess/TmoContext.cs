using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMO.DataAccess.Entities;

namespace TMO.DataAccess
{
    public class TmoContext
    {
        // simulate a database context, in this case we read fromn a file

        public List<Order> ReadCsv()
        {
            var orders = new List<Order>();
            var filePath = @".\orders.csv";

            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    var columns = line.Split(',');

                    if (columns[0].Equals("Seller"))
                    {
                        continue; // skip the header
                    }

                    orders.Add(new Order
                    {
                        Seller = columns[0],
                        Product = columns[1],
                        Price = decimal.Parse(columns[2]),
                        OrderDate = DateTime.Parse(columns[3]),
                        Branch = columns[4]
                    });
                }
            }
            catch (Exception)
            {
                // log the error
                throw;
            }
            
            return orders;
        }
    }
}
