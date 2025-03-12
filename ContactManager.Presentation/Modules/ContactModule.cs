using Carter;
using ContactManager.Contracts.DTO;
using ContactManager.Contracts.Interfaces;
using Microsoft.AspNetCore.Builder;

namespace ContactManager.Presentation.Modules
{
    public class ContactModule: ICarterModule
    {
        void ICarterModule.AddRoutes(IEndpointRouteBuilder app)
        {
            var apiGroup = app.MapGroup("/api").WithTags("Contacts");

            apiGroup.MapPost("/contact", (ContactDto contactDto, IContactService contactService) =>
            {
                var contact = contactService.CreateContact(contactDto);
                return Results.Ok(contact);
            });

            apiGroup.MapPut("/contact", (ContactDto contactDto, IContactService contactService) =>
            {
                var contact = contactService.UpdateContact(contactDto);
                return Results.Ok(contact);
            });

            apiGroup.MapGet("/contact/{id}", (Guid id, IContactService contactService) =>
            {
                var contact = contactService.GetContactById(id);
                return Results.Ok(contact);
            });

            apiGroup.MapGet("/contacts", (IContactService contactService) =>
            {
                var contacts = contactService.GetContacts();
                return Results.Ok(contacts);
            });

            apiGroup.MapDelete("/contact/{id}", (Guid id, IContactService contactService) =>
            {
                contactService.DeleteContact(id);
                return Results.Ok();
            });
        }
    }
}
