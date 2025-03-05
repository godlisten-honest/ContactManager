using Carter;
using ContactManager.Contracts;
using ContactManager.Contracts.DTO;
using ContactManager.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Presentation
{
    public class CustomerModule : ICarterModule
    {
        void ICarterModule.AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/customers",(ICustomerService customerService) => 
            {
                var customers=customerService.GetCustomers();
                return Results.Ok(customers);


            });

            app.MapGet("/customers/{id}", ( Guid id,ICustomerService customerService) =>
            {
                var customer = customerService.GetCustomerById(id);
                return Results.Ok(customer);


            });

            app.MapDelete("/customers/{id}", (Guid id,ICustomerService customerService) =>
            {
                customerService.DeleteCustomer(id);
                return Results.Ok();


            });

            app.MapPost("/customers", ( CreateCustomerDto createCustomerDto,ICustomerService customerService) =>
            {
                var customer = customerService.CreateCustomer(createCustomerDto);
                return Results.Ok(customer);


            });

            app.MapPut("/customers", (UpdateCustomerDto updateCustomerDto,ICustomerService customerService) =>
            {
                var customer = customerService.UpdateCustomer(updateCustomerDto);
                return Results.Ok(customer);

            });
        }
    }
}
