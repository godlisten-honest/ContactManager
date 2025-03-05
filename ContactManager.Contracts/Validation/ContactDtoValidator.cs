using ContactManager.Contracts.DTO;
using FluentValidation;

namespace ContactManager.Contracts.Validation
{
    public class ContactDtoValidator : AbstractValidator<ContactDto>
    {
        public ContactDtoValidator()
        {
            RuleFor(x => x.ContactName).NotEmpty().MaximumLength(150);
            RuleFor(x => x.ContactTitle).NotEmpty();
            RuleFor(x => x.TelephoneNo).NotEmpty();
            RuleFor(x => x.EmailAddress).NotEmpty();
        }
    }
}
