
using ContactManager.Contracts.DTO;
using ContactManager.Contracts.Interfaces;
using ContactManager.Contracts.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
namespace ContactManager.Contracts
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ContactDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<CustomerDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateCustomerDtoValidator>(); 
            services.AddValidatorsFromAssemblyContaining<UpdateCustomerDtoValidator>();

        }
    }
}
