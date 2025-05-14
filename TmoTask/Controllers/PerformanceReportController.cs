using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TMO.Services.Interface;

namespace TmoTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerformanceReportController : ControllerBase
    {
        private IOrderService _orderService { get; set; }

        public PerformanceReportController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet("getbranches")]
        public IActionResult GetBranches()
        {
            return this._orderService.GetAllBranches() != null ? Ok(this._orderService.GetAllBranches()) : NotFound("No branches found");
        }

        [HttpGet("bestsellersbybranch")]
        public IActionResult GetBestSellersByBranch(string branch)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(branch) == true)
                {
                    return BadRequest("Branch name cannot be null or empty");
                }

                var sellersByBranch = this._orderService.GetBestSellersByBranch(branch);

                if (sellersByBranch != null && sellersByBranch.Count > 0)
                {
                    return Ok(sellersByBranch);
                }
                else
                {
                    return NotFound("No orders found for the specified branch");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting orders. Error: {ex.InnerException?.Message ?? ex.Message}.");
            }
        }
    }
}
