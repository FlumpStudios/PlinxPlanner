using System.Collections.Generic;
using System.Threading.Tasks;
using PlinxPlanner.Common.Models;

namespace PlinxPlanner.Service.Contracts
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer(Customer customerDetails);
        Task<CustomerAddress> CreateCustomerAddress(int customerId, CustomerAddress customerAddress);
        Task<bool> DeleteCustomerDetails(int id);
        Task<IEnumerable<Customer>> GetCustomer();
        Task<Customer> GetCustomer(int id);
        Task<IEnumerable<CustomerAddress>> GetCustomerAddress(int customerId);
        Task<bool> UpdateCustomerDetails(int id, Customer customer);
    }
}