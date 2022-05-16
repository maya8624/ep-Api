using ep.Domain.Dtos;

namespace ep.Domain.Mappings
{
    public class APIProfile : Profile
    {
        public APIProfile()
        {
            // Source => Target
            CreateMap<CustomerCreateDto, Customer>()
                .ForMember(dest => dest.ShopId, opt => opt.MapFrom(src => src.Qi));
            CreateMap<ShopCreateDto, Shop>();
            //CreateMap<CustomerCreateDto, Message>()
            //    .ForMember(dest => dest.Recipient, opt => opt.MapFrom(src => src.Name));
            CreateMap<MessageCreateDto, Message>();
        }
    }
}
