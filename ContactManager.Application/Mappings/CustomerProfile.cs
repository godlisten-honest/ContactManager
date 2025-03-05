using AutoMapper;
using ContactManager.Contracts.DTO;
using ContactManager.Domain.Entities;

namespace ContactManager.Application.Mappings;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {

        CreateMap<CustomerDto, Customer>()
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<CustomerDto, CreateCustomerDto>().ReverseMap();
        CreateMap<CustomerDto, UpdateCustomerDto>().ReverseMap();

        CreateMap<CreateCustomerDto,Customer>()
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<UpdateCustomerDto,Customer>()
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<ContactDto, Contact>()
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModified, opt => opt.Ignore()).ReverseMap();

        
    }
}
