using AutoMapper;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Infrastructure.ViewModel;

namespace Test.Weelo.Infrastructure.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, Customer>()
                .ForMember(dest => dest.Id,
                        opt => opt.MapFrom(src => src.CustomerId))
                .ReverseMap();
        }
    }
}
