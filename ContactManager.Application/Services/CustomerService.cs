using AutoMapper;
using ContactManager.Contracts.DTO;
using ContactManager.Contracts.Interfaces;
using ContactManager.Domain.Entities;
using ContactManager.Domain.Interfaces;
using FluentValidation;

namespace ContactManager.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;
        private readonly IValidator<CreateCustomerDto> createCustomerValidator;
        private readonly IValidator<UpdateCustomerDto> updateCustomerValidator;

        public CustomerService(ICustomerRepository customerRepository,IMapper mapper, IValidator<CreateCustomerDto> createCustomerValidator, IValidator<UpdateCustomerDto> updateCustomerValidator)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
            this.createCustomerValidator = createCustomerValidator;
            this.updateCustomerValidator = updateCustomerValidator;
        }
        CustomerDto ICustomerService.CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            var validationResult = createCustomerValidator.Validate(createCustomerDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var customer = mapper.Map<Customer>(createCustomerDto);
            customerRepository.CreateCustomer(customer);
            var customerDto = mapper.Map<CustomerDto>(customer);
            return customerDto;
        }

        void ICustomerService.DeleteCustomer(Guid customerId)
        {
            customerRepository.DeleteCustomer(customerId);
        }

        CustomerDto ICustomerService.GetCustomerById(Guid customerId)
        {
            var customer=customerRepository.GetCustomerById(customerId);
            var customerDto= mapper.Map<CustomerDto>(customer);
            return customerDto;
        }

        IEnumerable<CustomerDto> ICustomerService.GetCustomers()
        {
            var customers=customerRepository.GetCustomers();
            var dtos = mapper.Map<IEnumerable<CustomerDto>>(customers);
            return dtos;
        }

        CustomerDto ICustomerService.UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var validationResult = updateCustomerValidator.Validate(updateCustomerDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var customer = mapper.Map<Customer>(updateCustomerDto);
            customerRepository.UpdateCustomer(customer);
            var customerDto = mapper.Map<CustomerDto>(customer);
            return customerDto;
        }
    }
}
