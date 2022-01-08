using AutoMapper;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Infrastructure.ViewModel;
using Test.Weelo.Service.Features.OwnerFeatures.Commands;

namespace Test.Weelo.Infrastructure.Mapping
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<CreateOwnerCommand, OwnerEntity>().ReverseMap();
            CreateMap<OwnerModel, OwnerEntity>().ReverseMap();
        }
    }
}
