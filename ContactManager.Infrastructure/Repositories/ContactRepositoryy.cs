using ContactManager.Domain.Entities;
using ContactManager.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ContactManager.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public ContactRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        Contact IContactRepository.CreateContact(Contact contact)
        {
            if (contact.ContactId == Guid.Empty)
            {
                contact.ContactId = Guid.NewGuid();
            }
            string connectionString = Configuration.GetConnectionString("ContactDBContext");
            using SqlConnection conn = new(connectionString);
            {
                conn.Execute("Insert into Contacts(ContactId, CustomerId, ContactName, ContactTitle, TelephoneNo, EmailAddress)" +
                    "values (@ContactId, @CustomerId, @ContactName, @ContactTitle, @TelephoneNo, @EmailAddress)",
                    new { contact.ContactId, contact.CustomerId, contact.ContactName, contact.ContactTitle, contact.TelephoneNo, contact.EmailAddress });
                return contact;
            }
        }

        void IContactRepository.DeleteContact(Guid contactId)
        {
            string connectionString = Configuration.GetConnectionString("ContactDBContext");
            using SqlConnection conn = new(connectionString);
            {
                conn.Execute("Delete Contacts where ContactId=@ContactId", new { contactId });
            }
        }

        Contact? IContactRepository.GetContactById(Guid contactId)
        {
            string connectionString = Configuration.GetConnectionString("ContactDBContext");
            using SqlConnection conn = new(connectionString);
            {
                var contact = conn.QueryFirstOrDefault<Contact>("Select * from Contacts where ContactId=@ContactId", new { contactId });
                return contact;
            }
        }

        List<Contact> IContactRepository.GetContacts()
        {
            string connectionString = Configuration.GetConnectionString("ContactDBContext");
            using SqlConnection conn = new(connectionString);
            {
                var contacts = conn.Query<Contact>("Select * from Contacts");
                return contacts.ToList();
            }
        }

        Contact IContactRepository.UpdateContact(Contact contact)
        {
            string connectionString = Configuration.GetConnectionString("ContactDBContext");
            using SqlConnection conn = new(connectionString);
            {
                conn.Execute("Update Contacts set ContactId=@ContactId, CustomerId=@CustomerId, ContactName=@ContactName, ContactTitle=@ContactTitle, TelephoneNo=@TelephoneNo, EmailAddress=@EmailAddress)",
                    new { contact.ContactId, contact.CustomerId, contact.ContactName, contact.ContactTitle, contact.TelephoneNo, contact.EmailAddress });
                return contact;
            }
        }
    }
}
