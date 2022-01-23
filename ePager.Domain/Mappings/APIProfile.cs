using AutoMapper;
using ePager.Domain.Dtos;
using ePager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePager.Domain.Mappings
{
    public class APIProfile : Profile
    {
        public APIProfile()
        {
            // Source => Target
          
            CreateMap<CustomerCreateDto, Customer>();
            //CreateMap<CustomerCreateDto, Message>()
            //    .ForMember(dest => dest.Recipient, opt => opt.MapFrom(src => src.Name));
        }
    }
}
