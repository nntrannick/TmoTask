using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMO.DataAccess.Entities;

namespace TMO.Services.Interface
{
    public interface IOrderService
    {
        List<string> GetAllBranches();
        List<Order> GetAllOrders();
        List<SellerPerformance> GetBestSellersByBranch(string branch);
    }
}
