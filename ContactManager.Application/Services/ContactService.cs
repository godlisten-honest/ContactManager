using AutoMapper;
using ContactManager.Contracts.DTO;
using ContactManager.Contracts.Interfaces;
using ContactManager.Domain.Entities;
using ContactManager.Domain.Interfaces;
using FluentValidation;

namespace ContactManager.Application
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;
        private readonly IMapper mapper;
        private readonly IValidator<ContactDto> contactValidator;

        public ContactService(IContactRepository contactRepository, IMapper mapper, IValidator<ContactDto> contactValidator)
        {
            this.contactRepository = contactRepository;
            this.mapper = mapper;
            this.contactValidator = contactValidator;
        }

        ContactDto IContactService.CreateContact(ContactDto contactDto)
        {
            var validatorResult = contactValidator.Validate(contactDto);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }

            var contact = mapper.Map<Contact>(contactDto);
            contactRepository.CreateContact(contact);
            var resultContactDto = mapper.Map<ContactDto>(contact);
            return resultContactDto;
        }

        void IContactService.DeleteContact(Guid contactId)
        {
            contactRepository.DeleteContact(contactId);
        }

        ContactDto IContactService.GetContactById(Guid contactId)
        {
            var contact = contactRepository.GetContactById(contactId);
            var contactResult = mapper.Map<ContactDto>(contact);
            return contactResult;
        }

        IEnumerable<ContactDto> IContactService.GetContacts()
        {
            var contacts = contactRepository.GetContacts();
            var contactsResult = mapper.Map<IEnumerable<ContactDto>>(contacts);
            return contactsResult;
        }

        ContactDto IContactService.UpdateContact(ContactDto contactDto)
        {
            var validateResult = contactValidator.Validate(contactDto);
            
            if (!validateResult.IsValid)
            {
                throw new ValidationException(validateResult.Errors);
            }

            var contact = mapper.Map<Contact>(contactDto);
            contactRepository.UpdateContact(contact);
            var contactResult = mapper.Map<ContactDto>(contact);
            return contactResult;
        }
    }
}
