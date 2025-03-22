using DummyApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace DummyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeDetailController : ControllerBase
    {
        private readonly ILogger<EmployeeDetail> _logger;
        private List<EmployeeDetail> EmployeeDetailsList;
        public EmployeeDetailController(ILogger<EmployeeDetail> logger)
        {
            _logger = logger;
            EmployeeDetailsList = new List<EmployeeDetail>();
        }

        [HttpGet(Name = "GetEmployeeDetail")]
        public IEnumerable<EmployeeDetail> Get()
        {
            EmployeeDetailsList.Add( new EmployeeDetail { EmpId = 1, EmpName = "Pragya", EmpEmail = "Pragya@chickooo.com", Salary = 10000000 });
            return EmployeeDetailsList;
        }

        [HttpPost(Name = "SetEmployeeDetail")]
        public IActionResult SetEmployeeDetail([FromBody] EmployeeDetail empDtl)
        {
            EmployeeDetailsList.Add(empDtl);
            return new OkObjectResult(true);
           // return EmployeeDetailsList;
        }
    }
}
