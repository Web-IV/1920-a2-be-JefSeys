using GameStoreBackEnd.DTOs;
using GameStoreBackEnd.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreBackEnd.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [AllowAnonymous]
        [HttpGet()]
        public ActionResult<CustomerDTO> GetCustomer(string email)
        {
            if(email == "" || email is null)
            {
                return null;
            }
            else
            {
                Customer customer = _customerRepository.GetByEmail(email);
                return new CustomerDTO(customer);
            }
        }
    }
}
