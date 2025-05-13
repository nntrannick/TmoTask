using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace TmoTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerformanceReportController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string branch)
        {
            throw new NotImplementedException();
        }
    }
}
