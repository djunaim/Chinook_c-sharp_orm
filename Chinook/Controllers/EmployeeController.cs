using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Chinook.Data;

namespace Chinook.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeRepository _employeeRepository = new EmployeeRepository();

        [HttpGet("{title}")]
        public IActionResult GetEmployee(string title)
        {
            var employees = _employeeRepository.GetEmployee(title);
            if (!employees.Any())
            {
                return NotFound();
            }
            return Ok(employees);
        }
    }
}