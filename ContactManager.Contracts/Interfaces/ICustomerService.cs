using ContactManager.Contracts.DTO;

namespace ContactManager.Contracts.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetCustomers();
        CustomerDto CreateCustomer(CreateCustomerDto customerDto);
        CustomerDto UpdateCustomer(UpdateCustomerDto customerDto);
        void DeleteCustomer(Guid customerId);
        CustomerDto GetCustomerById(Guid customerId);
    }
}
