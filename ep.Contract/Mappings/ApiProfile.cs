using AutoMapper;
using ep.Contract.Dtos;
using ep.Contract.ViewModels;
using ep.Domain.Models;

namespace ep.Contract.Mappings
{
    public class APIProfile : Profile
    {
        public APIProfile()
        {
            // Source => Target
            CreateMap<CustomerCreateDto, Customer>()
                .ForMember(dest => dest.ShopId, opt => opt.MapFrom(src => src.Qi));

            CreateMap<ShopCreateDto, Shop>();
            
            CreateMap<MessageCreateDto, Message>();

            CreateMap<Business, BusinessView>();
        }
    }
}
