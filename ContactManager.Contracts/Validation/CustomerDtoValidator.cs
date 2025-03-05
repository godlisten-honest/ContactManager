using ContactManager.Contracts.DTO;
using FluentValidation;

namespace ContactManager.Contracts.Validation;

public class CustomerDtoValidator : AbstractValidator<CustomerDto>
{
    public CustomerDtoValidator()
    {
        RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(150);
        RuleForEach(x => x.Contacts).SetValidator(new ContactDtoValidator());
    }
}

