using ep.Domain.Dtos;

namespace ep.Domain.Mappings
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
