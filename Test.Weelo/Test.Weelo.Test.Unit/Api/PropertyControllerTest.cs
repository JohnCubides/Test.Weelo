﻿
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using Test.Weelo.Controllers;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Infrastructure.ViewModel;
using Test.Weelo.Service.Features.PropertyFeatures.Commands;

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

            PropertyController ownerController = new PropertyController(mediator.Object, mapper.Object);

            var result = await ownerController.Create(It.IsAny<CreatePropertyCommand>());
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}