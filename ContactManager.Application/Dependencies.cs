using ContactManager.Application.Mappings;
using ContactManager.Contracts.Interfaces;
using ContactManager.Contracts.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
namespace ContactManager.Application
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CustomerProfile));
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddValidatorsFromAssemblyContaining<CustomerDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<ContactDtoValidator>();
        }
    }
}
