using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHDTest.Managers;
using BHDTest.Models;
using BHDTest.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BHDTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomersManager _customersManager;
        public CustomersController(CustomersManager customersManager)
        {
            _customersManager = customersManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequest customerRequest)
        {
            var customer = new Customers
            {
                DocumentNumber = customerRequest.DocumentNumber,
                FullName = customerRequest.FullName,
                CreditLimit = customerRequest.CreditLimit
            };

            try
            {
                Customers result = await _customersManager.CreateCustomer(customer);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}