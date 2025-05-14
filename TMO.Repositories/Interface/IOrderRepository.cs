using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMO.DataAccess.Entities;

namespace TMO.Repositories.Interface
{
    public interface IOrderRepository
    {
        List<string> GetAllBranches();
        List<Order> GetAllOrders();
    }
}
