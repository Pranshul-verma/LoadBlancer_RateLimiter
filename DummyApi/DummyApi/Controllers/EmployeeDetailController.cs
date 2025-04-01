using DummyApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace DummyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeDetailController : ControllerBase
    {
        private readonly ILogger<EmployeeDetail> _logger;
        private static List<EmployeeDetail>? EmployeeDetailsList;
        public EmployeeDetailController(ILogger<EmployeeDetail> logger)
        {
            _logger = logger;
            if (EmployeeDetailsList == null) { EmployeeDetailsList = new List<EmployeeDetail>(); }
        }

        [HttpGet(Name = "GetEmployeeDetail")]
        public IActionResult Get()
        {
            if (EmployeeDetailsList?.Count == 0)
            {
                return NotFound("No data found.");
            }

            // Return all data in the collection
            return Ok(EmployeeDetailsList);
        }

        [HttpPost(Name = "SetEmployeeDetail")]
        public IActionResult SetEmployeeDetail([FromBody] EmployeeDetail empDtl)
        {

            if (empDtl==null)
            {
                return BadRequest("Data cannot be empty.");
            }

            // Add new data to the collection
            EmployeeDetailsList?.Add(empDtl);
            return Ok(EmployeeDetailsList);
        }
    }
}
