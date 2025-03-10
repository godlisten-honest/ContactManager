using AutoMapper;
using ContactManager.Contracts.DTO;
using ContactManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Application.Mappings
{
    public class ContactProfile: Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactDto, Contact>()
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore());
                
        }
    }
}
