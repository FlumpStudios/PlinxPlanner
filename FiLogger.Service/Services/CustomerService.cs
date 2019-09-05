using PlinxPlanner.Common.Models;
using PlinxPlanner.DataAccess.Contracts.RepositoryContracts;
using PlinxPlanner.DataAccess.EntityFramework;
using PlinxPlanner.Service.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlinxPlanner.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService( 
            ICustomerRepository customerRepository, 
            ILogger<CustomerService> logger)
        {            
            _repository = customerRepository;
            _logger = logger;
        }


        #region Get Methods
        public async Task<IEnumerable<Customer>> GetCustomer()
         {
            IEnumerable<Customer> customer = null;

            try
            {
                customer = await _repository.GetCustomer();
            }
            catch (Exception e)
            {
                _logger.LogError("Error Retrieving list of CustomerDetails", e);
                throw;
            }

            return customer;            
         }

        public async Task<Customer> GetCustomer(int id)
        {

            Customer customerDetails = null;

            try
            {
                customerDetails = await _repository.GetCustomer(id);
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("Could not retrieve customer with the ID of {0}",id), e);
            }

            return customerDetails;
        }

        public async Task<IEnumerable<CustomerAddress>> GetCustomerAddress(int customerId)
        {
            IEnumerable<CustomerAddress> customerAddress = null;

            try
            {
                customerAddress = await _repository.GetCustomerAddress(customerId);
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("Could not retrieve customers address with the customer id ID of {0}", customerId), e);
            }

            return customerAddress;
        }
 
        #endregion


        #region Create methods
        public async Task<Customer> CreateCustomer(Customer customerDetails)
        {
            Customer returnedCustomerDetails = null;

            try
            {
                returnedCustomerDetails = _repository.AddCustomer(customerDetails);
                await _repository.SaveAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("Error creating new customer", e);
                throw;
            }

            return returnedCustomerDetails;
        }

        public async Task<CustomerAddress> CreateCustomerAddress(int customerId, CustomerAddress customerAddress)
        {
            //If no id in the address model assign provided ID to model
            if (customerAddress.CustomerId == 0) customerAddress.CustomerId = customerId;

            //Check the provided customer id is the same as the customer id in the model.
            if (customerId != customerAddress.CustomerId)
            {
                 throw new Exception("ID mismatch between provided customer ID and customer ID contained in address object");
            }

            CustomerAddress returnedCustomerAddress = null;

            try
            {
                returnedCustomerAddress = _repository.AddCustomerAddress(customerAddress);
                await _repository.SaveAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("Error creating new customer address", e);
                throw;
            }

            return returnedCustomerAddress;
        }
   
        #endregion


        #region Update methods
        public async Task<bool> UpdateCustomerDetails(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                _logger.LogInformation(string.Format("ID mismatch between provided ID({0}) and the ID contained in Customer Record ({1})",id,customer.CustomerId));
                return false;
            }

            _repository.UpdateCustomer(customer);

            try
            {
                await _repository.SaveAsync();               
            }
            catch (Exception e)
            {
                if (!_repository.CustomerDetailsExists(id))
                {
                    _logger.LogInformation(string.Format("Could not find customer with id {0} when trying to update details", id), e);
                    return false;                         
                }
                else
                {
                    _logger.LogError(string.Format("Error attempting to update customerDetails with id {0}", id), e);
                    throw;
                }
            }
            return true;
        }
        #endregion


        #region Delete methods
        public async Task<bool> DeleteCustomerDetails(int id)
        {            
            if (!_repository.CustomerDetailsExists(id))
            {
                _logger.LogInformation(string.Format("Could not find Customer with Id {0} when attempting to delete", id));
                return false;
            }

            try
            {
                _repository.DeleteCustomer(id);
                await _repository.SaveAsync();
            }

            catch(Exception e)
            {
                _logger.LogError(string.Format("Error attempting to delete customer with the id {0}", id), e);
                 throw;
            }

            return true;
        }            
        #endregion
    }
}
