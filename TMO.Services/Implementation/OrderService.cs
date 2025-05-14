using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TMO.DataAccess.Entities;
using TMO.Repositories.Interface;
using TMO.Services.Interface;

namespace TMO.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public List<string> GetAllBranches()
        {
            return this._orderRepository.GetAllBranches();
        }

        public List<Order> GetAllOrders()
        {
            return this._orderRepository.GetAllOrders();
        }

        public List<SellerPerformance> GetBestSellersByBranch(string branch)
        {
            var orders = this._orderRepository.GetAllOrders();

            var results = orders
                .Where(o => o.Branch == branch) // Filter by branch
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month, o.Seller }) // Group by year, month, and seller
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    g.Key.Seller,
                    TotalPrice = g.Sum(o => o.Price), // Sum the prices for each seller in the group
                    TotalOrders = g.Count() // Count orders for each seller in the group
                })
                .GroupBy(g => new { g.Year, g.Month }) // Group by year and month
                .Select(g => g.OrderByDescending(s => s.TotalPrice).First()) // Get the seller with the highest sales
                .Select(result => new SellerPerformance { 
                        Month = new DateTime(result.Year, result.Month, 1).ToString("MMMM"), 
                        Seller = result.Seller, 
                        TotalOrder = result.TotalOrders, 
                        TotalPrice = result.TotalPrice
                    } 
                )
                .ToList();

            return results;
        }
    }
}
