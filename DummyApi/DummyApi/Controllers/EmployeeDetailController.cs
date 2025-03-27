using DummyApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace DummyApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeDetailController : ControllerBase
    {
       // private readonly ILogger<IEmployeeDetail> _logger;
        private List<EmployeeDetail> EmployeeDetailsList = new List<EmployeeDetail>();
        public EmployeeDetailController()
        {
            //_logger = logger;
            
        }

        [HttpGet(Name = "GetEmployeeDetail")]
        //[Route("~/Get")]
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
