using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlinxPlanner.Common.Models;
using PlinxPlanner.Context.Data;

namespace PlinxPlanner.API.Controllers
{
    /// <summary>
    /// Version 2 of the Customer Controller
    /// </summary>
    [ApiVersion("2.0")]
    [Route("api/v2/[controller]")]
    [ApiController]    
    public class CustomerControllerV2 : ControllerBase
    {
        private readonly AP_ReplacementContext _context;

        /// <summary>
        /// Constructor method for the customer details controller
        /// </summary>
        /// <param name="context"></param>
        public CustomerControllerV2(AP_ReplacementContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get customer via their ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerDetails()
        {
            await _context.Customer.ToListAsync();
            throw new NotImplementedException("Version 2 of API is not live");
        }

    }
}
