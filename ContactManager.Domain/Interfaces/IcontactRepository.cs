using ContactManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Domain.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetContacts();
        Contact CreateContact(Contact contact);
        Contact UpdateContact(Contact contact);
        Contact GetContactById(Guid contactId);

        void DeleteContact(Guid contactId);

    }
}
