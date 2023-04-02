using AutoMapper;
using ep.Contract.RequestModels;
using ep.Contract.ViewModels;
using ep.Domain.Models;

namespace ep.Contract.Mappings
{
    public class APIProfile : Profile
    {
        public APIProfile()
        {
            // Source => Target
            CreateMap<CustomerRequest, Customer>()
                .ForMember(dest => dest.ShopId, opt => opt.MapFrom(src => src.Qi));

            CreateMap<MessageRequest, Message>();
            CreateMap<Business, BusinessView>();
            CreateMap<BusinessRequest, Business>();
            CreateMap<RegisterRequest, User>();
            CreateMap<User, UserView>();
        }
    }
}
