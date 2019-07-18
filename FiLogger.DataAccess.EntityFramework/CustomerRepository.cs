using PlinxPlanner.Common.Models;
using PlinxPlanner.Context.Data;
using PlinxPlanner.DataAccess.Contracts.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlinxPlanner.DataAccess.EntityFramework
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AP_ReplacementContext _context;

        public CustomerRepository(AP_ReplacementContext context)
        {
            _context = context;
        }

        #region Get request
        public async Task<IEnumerable<Customer>> GetCustomer() => await _context.Customer.
            AsNoTracking().
            Include(x => x.CustomerAddress).
            Include(x => x.Sitedetails)
            .ToListAsync();
        public async Task<Customer> GetCustomer(int id) => await _context.Customer.
            AsNoTracking().
            Include(x => x.CustomerAddress).
            Include(x => x.Sitedetails).
            Include(x => x.CustomerAddress).SingleOrDefaultAsync(i => i.CustomerId == id);
        public async Task<IEnumerable<CustomerAddress>> GetCustomerAddress(int id) => await _context.CustomerAddress.Where(i => i.CustomerId == id).ToListAsync();     
        #endregion
        
        #region Post request
        public Customer AddCustomer(Customer customer) => _context.Customer.Add(customer).Entity;
        public CustomerAddress AddCustomerAddress(CustomerAddress customerAddress) => _context.CustomerAddress.Add(customerAddress).Entity;
        #endregion


        #region Put request
        public void UpdateCustomer(Customer customerDetails) => _context.Update(customerDetails);
        #endregion

        #region Delete Request       
        public void DeleteCustomer(int id) => _context.Customer.Remove(_context.Customer.Find(id));
        #endregion

        public bool CustomerDetailsExists(int id) => _context.Customer.ToList().Any(e => e.CustomerId == id);      
        public void Save() => _context.SaveChanges();
        public async Task SaveAsync() => await _context.SaveChangesAsync();

        #region Destructor       
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
