using AutoMapper;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Infrastructure.ViewModel;
using Test.Weelo.Service.Features.PropertyImageFeatures.Commands;

namespace Test.Weelo.Infrastructure.Mapping
{
    public class PropertyImageProfile: Profile
    {
        public PropertyImageProfile()
        {
            CreateMap<CreatePropertyImageCommand, PropertyImageEntity>().ReverseMap();
            CreateMap<PropertyImageEntity, PropertyImageModel>().ReverseMap();
        }
    }
}
