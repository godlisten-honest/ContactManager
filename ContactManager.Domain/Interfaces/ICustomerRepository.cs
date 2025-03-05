using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.Domain.Entities;

namespace ContactManager.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(Guid customerId);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomer(Guid customerId);
    }
}
