using AutoMapper;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Infrastructure.ViewModel;
using Test.Weelo.Service.Features.PropertyFeatures.Commands;

namespace Test.Weelo.Infrastructure.Mapping
{
    public class PropertyProfile:Profile
    {
        public PropertyProfile()
        {
            CreateMap<CreatePropertyCommand, PropertyEntity>().ReverseMap();
            CreateMap<PropertyModel, PropertyEntity>().ReverseMap();
            CreateMap<UpdatePropertyCommand, PropertyEntity>().ReverseMap();
        }
    }
}
