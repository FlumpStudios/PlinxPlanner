using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PlinxPlanner.Service.Contracts;
using vm = PlinxPlanner.API.DataContracts;
using dm = PlinxPlanner.Common.Models;
using Microsoft.AspNetCore.Authorization;

namespace PlinxPlanner.API.Controllers.V1
{
    /// <summary>
    /// Customer details controller
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;

        /// <summary>
        /// Constructor method for the customer details controller
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public CustomerController(IMapper mapper,
             ICustomerService service)
        {
            _mapper = mapper;
            _service = service;
        }


        #region Get Requests
        /// <summary>
        /// Return full list of customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<IEnumerable<vm.Response.Customer>>> Get()
        {
            return _mapper.Map<IEnumerable<vm.Response.Customer>>(await _service.GetCustomer()).ToList();
        }

        /// <summary>
        /// Get customer via their ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<vm.Response.Customer>> Get(int id)
        {
            return _mapper.Map<vm.Response.Customer>(await _service.GetCustomer(id)); 
        }

        /// <summary>
        /// Get list of customer addresses
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>     
       
        [HttpGet("{id:int}/address")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<IEnumerable<vm.Response.CustomerAddress>>> GetAddresses(int id)
        {
            return _mapper.Map<IEnumerable<vm.Response.CustomerAddress>>(await _service.GetCustomerAddress(id)).ToList(); ;
        }
        #endregion


        #region Post Requests
        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="customerDetails"></param>
        /// <returns></returns>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<ActionResult<vm.Response.Customer>> Post(vm.Request.CustomerPostRequest customerDetails)
        {          
            var createdDetails = _mapper.Map<vm.Response.Customer>(await _service.CreateCustomer(Mapper.Map<dm.Customer>(customerDetails)));            
            return CreatedAtAction("Get", new { id = createdDetails.CustomerId }, createdDetails);
        }

        /// <summary>
        /// Create a new address for customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="customerAddress"></param>
        /// <returns></returns>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Route("address")]
        [HttpPost]
        public async Task<ActionResult<vm.Response.CustomerAddress>> PostCustomerAddress(int customerID, vm.Request.CustomerAddressPostRequest customerAddress)
        {
            var createdDetails = _mapper.Map<vm.Response.CustomerAddress>(await _service.CreateCustomerAddress(customerID, Mapper.Map<dm.CustomerAddress>(customerAddress)));
            return CreatedAtAction("Get", new { id = createdDetails.CustomerId }, createdDetails);
        }
        #endregion


        #region Put Requests
        /// <summary>
        /// Update a customer record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerDetails"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, vm.Request.CustomerPostRequest customerDetails)
        {
            var updateSuccessful = await _service.UpdateCustomerDetails(id, Mapper.Map<dm.Customer>(customerDetails));
            if (updateSuccessful) return Ok(string.Format("Customer with ID of {0} was successfully updated", id));
            return BadRequest();
        }
        #endregion

        #region Delete Requests
        /// <summary>
        /// Delete a customer record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteSuccessful = await _service.DeleteCustomerDetails(id);
            if (deleteSuccessful) return Ok(string.Format("Customer with ID of {0} was successfully deleted",id));
            return BadRequest();             
        }
        #endregion
    }
}
