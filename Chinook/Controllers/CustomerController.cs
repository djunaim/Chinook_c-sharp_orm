using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Chinook.Data;

namespace Chinook.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerRepository _repository = new CustomerRepository();

        //api/customer/brazil
        [HttpGet("{country}")]
        public IActionResult GetByCountry(string country)
        {
            var customers = _repository.GetByCountry(country);
            if (!customers.Any())
            {
                return NotFound();
            }
            return Ok(customers);
        }

        [HttpGet("invoice/{country}")]
        public IActionResult GetInvoiceByCountry(string country)
        {
            var customers = _repository.GetInvoiceByCountry(country);
            if (!customers.Any())
            {
                return NotFound();
            }
            return Ok(customers);
        }

    }
}