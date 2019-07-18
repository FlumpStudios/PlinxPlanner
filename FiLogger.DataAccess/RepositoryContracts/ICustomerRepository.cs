using System.Collections.Generic;
using System.Threading.Tasks;
using PlinxPlanner.Common.Models;

namespace PlinxPlanner.DataAccess.Contracts.RepositoryContracts
{
    public interface ICustomerRepository
    {
        Customer AddCustomer(Customer customer);
        CustomerAddress AddCustomerAddress(CustomerAddress customerAddress);
        bool CustomerDetailsExists(int id);
        void DeleteCustomer(int id);
        void Dispose();
        Task<IEnumerable<Customer>> GetCustomer();
        Task<Customer> GetCustomer(int id);
        Task<IEnumerable<CustomerAddress>> GetCustomerAddress(int id);
        void Save();
        Task SaveAsync();
        void UpdateCustomer(Customer customerDetails);
    }
}