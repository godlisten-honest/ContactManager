using ContactManager.Contracts.DTO;

namespace ContactManager.Contracts.Interfaces
{
    public interface IContactService
    {
        IEnumerable<ContactDto> GetContacts();
        ContactDto CreateContact(ContactDto contactDto);
        ContactDto UpdateContact(ContactDto contactDto);
        ContactDto GetContactById(Guid contactId);
        void DeleteContact(Guid contactId);
    }
}
