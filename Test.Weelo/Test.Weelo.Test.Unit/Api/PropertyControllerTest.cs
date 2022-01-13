
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Test.Weelo.Controllers;
using Test.Weelo.Domain.Dto.PropertyDto;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Infrastructure.ViewModel;
using Test.Weelo.Service.Features.PropertyFeatures.Commands;
using Test.Weelo.Service.Features.PropertyFeatures.Queries;

namespace Test.Weelo.Test.Unit.Api
{
    public class PropertyControllerTest
    {
        [Test]
        public async Task CreatePost_ReturnOkStatus()
        {
            PropertyModel propertyModel = new PropertyModel() { IdProperty = 1 };
            PropertyEntity propertyEntity = new PropertyEntity() { IdProperty = 1 };
            Mock<IMapper> mapper = new Mock<IMapper>();
            mapper.Setup(map => map.Map<PropertyModel>(It.IsAny<OwnerEntity>())).Returns(propertyModel);

            Mock<IMediator> mediator = new Mock<IMediator>();
            mediator.Setup(med => med.Send(It.IsAny<CreatePropertyCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(propertyEntity);

            PropertyController PropertyController = new PropertyController(mediator.Object, mapper.Object);

            var result = await PropertyController.Create(It.IsAny<CreatePropertyCommand>());
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public async Task Put_UpdatePriceProperty()
        {

            PropertyEntity propertyEntity = new PropertyEntity() { IdProperty = 1 };
            

            Mock<IMediator> mediator = new Mock<IMediator>();
            mediator.Setup(med => med.Send(It.IsAny<UpdatePricePropertyCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(1);
            Mock<IMapper> mapper = new Mock<IMapper>();
            PropertyController PropertyController = new PropertyController(mediator.Object, mapper.Object);

            var result = await PropertyController.UpdatePrice(1,25000);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public async Task Put_UpdateProperty()
        {

            PropertyEntity propertyEntity = new PropertyEntity() { IdProperty = 1 };

            UpdatePropertyCommand command = new UpdatePropertyCommand() { IdProperty = 3, IdOwner = 1, Name = "name", Price = 1500 };


            Mock<IMediator> mediator = new Mock<IMediator>();
            mediator.Setup(med => med.Send(It.IsAny<UpdatePropertyCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(1);
            Mock<IMapper> mapper = new Mock<IMapper>();
            PropertyController PropertyController = new PropertyController(mediator.Object, mapper.Object);

            var result = await PropertyController.Update(1, command);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public async Task POST_GetAll()
        {

            List<PropertyEntity> propertyEntityList = new List<PropertyEntity>() { 
                new PropertyEntity() { IdProperty=1},
                new PropertyEntity() { IdProperty=1}
            };

            PropertyFiltersResponseDto PropertyResponse = new PropertyFiltersResponseDto(){Properties = propertyEntityList};
            GetAllPropertyFiltersQuery query = new GetAllPropertyFiltersQuery() { Filters = new FilterPropertyDto() { Name="prueba" } };


            Mock<IMediator> mediator = new Mock<IMediator>();
            mediator.Setup(med => med.Send(It.IsAny<GetAllPropertyFiltersQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(PropertyResponse);
            Mock<IMapper> mapper = new Mock<IMapper>();
            PropertyController PropertyController = new PropertyController(mediator.Object, mapper.Object);

            var result = await PropertyController.GetAll(query);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
