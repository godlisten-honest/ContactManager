using ContactManager.Domain.Interfaces;
using ContactManager.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace ContactManager.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
