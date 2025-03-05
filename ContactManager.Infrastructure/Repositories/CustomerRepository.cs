using ContactManager.Domain.Entities;
using ContactManager.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ContactManager.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        public CustomerRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        Customer ICustomerRepository.CreateCustomer(Customer customer)
        {
            // Ensure the CustomerId is assigned
            if (customer.CustomerId == Guid.Empty)
            {
                customer.CustomerId = Guid.NewGuid();
            }
            string connectionString = Configuration.GetConnectionString("ContactDbContext");
            using SqlConnection conn = new(connectionString);
            conn.Execute("Insert into Customers(CustomerId,CustomerName) values(@CustomerId,@CustomerName)", new { customer.CustomerId, customer.CustomerName });
            return customer;
        }

        void ICustomerRepository.DeleteCustomer(Guid customerId)
        {
            string connectionString = Configuration.GetConnectionString("ContactDbContext");
            using SqlConnection conn = new(connectionString);
            {
                conn.Execute("Delete Customers  where CustomerId=@CustomerId", new { CustomerId = customerId });
            }
        }

        Customer ICustomerRepository.GetCustomerById(Guid customerId)
        {
            string connectionString = Configuration.GetConnectionString("ContactDbContext");
            using SqlConnection conn = new(connectionString);
            {
                var customer = conn.QueryFirst<Customer>("select * from Customers where CustomerId=@CustomerId",new {  CustomerId=customerId});
                return customer;

            }
        }

        List<Customer> ICustomerRepository.GetCustomers()
        {
            string connectionString = Configuration.GetConnectionString("ContactDbContext");
            using SqlConnection conn = new(connectionString);
            {
                var customers = conn.Query<Customer>("select * from Customers");
                return customers.ToList();

            }
        }

        Customer ICustomerRepository.UpdateCustomer(Customer customer)
        {
            string connectionString = Configuration.GetConnectionString("ContactDbContext");
            using SqlConnection conn = new(connectionString);
            {
                conn.Execute("Update Customers Set CustomerName=@CustomerName where CustomerId=@CustomerId",new { customer.CustomerId,customer.CustomerName});
                return customer;

            }
        }
    }
}
