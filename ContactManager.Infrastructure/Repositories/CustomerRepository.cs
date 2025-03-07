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
            

            try
            {
                // Insert the customer
                conn.Execute("Insert into Customers(CustomerId,CustomerName) values(@CustomerId,@CustomerName)",
                    new { customer.CustomerId, customer.CustomerName });

                // Insert the contacts
                if (customer.Contacts != null)
                {
                    foreach (var contact in customer.Contacts)
                    {
                        contact.ContactId = Guid.NewGuid(); // Ensure each contact has a unique ContactId
                        contact.CustomerId = customer.CustomerId; // Set the CustomerId for the contact
                        conn.Execute("Insert into Contacts(ContactId,CustomerId,ContactName,ContactTitle,TelephoneNo,EmailAddress) " +
                            "values(@ContactId,@CustomerId,@ContactName,@ContactTitle,@TelephoneNo,@EmailAddress)",
                            new { contact.ContactId, contact.CustomerId, contact.ContactName, contact.ContactTitle, contact.TelephoneNo, contact.EmailAddress });
                    }
                }

            }
            catch
            {
                throw;
            }

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
            //{
            //    var customer = conn.QueryFirst<Customer>("select * from Customers where CustomerId=@CustomerId",new {  CustomerId=customerId});
            //    return customer;

            //}
            {
                var customerDictionary = new Dictionary<Guid, Customer>();

                var customer = conn.Query<Customer, Contact, Customer>(
                    "SELECT c.*, ct.* FROM Customers c LEFT JOIN Contacts ct ON c.CustomerId = ct.CustomerId",
                    (customer, contact) =>
                    {
                        if (!customerDictionary.TryGetValue(customer.CustomerId, out var customerEntry))
                        {
                            customerEntry = customer;
                            customerEntry.Contacts = new List<Contact>();
                            customerDictionary.Add(customer.CustomerId, customerEntry);
                        }

                        if (contact != null)
                        {
                            customerEntry.Contacts.Add(contact);
                        }

                        return customerEntry;
                    },
                    splitOn: "ContactId"
                ).Distinct().ToList();

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
