using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMO.DataAccess;
using TMO.DataAccess.Entities;
using TMO.Repositories.Interface;

namespace TMO.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TmoContext _context = new TmoContext();

        public List<string> GetAllBranches()
        {
            var branches = this.GetAllOrders()
                .Select(x => x.Branch)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            return branches;
        }

        public List<Order> GetAllOrders()
        {
            var orders = this._context.ReadCsv();

            return orders;
        }
    }
}
