using Carter;
using ContactManager.Contracts.DTO;
using ContactManager.Contracts.Interfaces;

namespace ContactManager.Presentation.Modules
{
    public class ContactModule: ICarterModule
    {
        void ICarterModule.AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/contact", (ContactDto contactDto, IContactService contactService) =>
            {
                var contact = contactService.CreateContact(contactDto);
                return Results.Ok(contact);
            })
                .WithTags("Contacts");

            app.MapPut("/contact", (ContactDto contactDto, IContactService contactService) =>
            {
                var contact = contactService.UpdateContact(contactDto);
                return Results.Ok(contact);
            })
                .WithTags("Contacts");

            app.MapGet("/contact/{id}", (Guid id, IContactService contactService) =>
            {
                var contact = contactService.GetContactById(id);
                return Results.Ok(contact);
            })
                .WithTags("Contacts");

            app.MapGet("/contacts", (IContactService contactService) =>
            {
                var contacts = contactService.GetContacts();
                return Results.Ok(contacts);
            })
                .WithTags("Contacts");

            app.MapDelete("/contact/{id}", (Guid id, IContactService contactService) =>
            {
                contactService.DeleteContact(id);
                return Results.Ok();
            })
                .WithTags("Contacts");
        }
    }
}
