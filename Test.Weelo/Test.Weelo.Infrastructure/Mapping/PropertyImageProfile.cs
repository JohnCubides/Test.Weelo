using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Infrastructure.ViewModel;
using Test.Weelo.Service.Features.PropertyFeatures.Commands;

namespace Test.Weelo.Infrastructure.Mapping
{
    public class PropertyImageProfile: Profile
    {
        public PropertyImageProfile()
        {
            CreateMap<CreatePropertyCommand, PropertyImageEntity>().ReverseMap();
            CreateMap<PropertyImageEntity, PropertyImageModel>().ReverseMap();
        }
    }
}
