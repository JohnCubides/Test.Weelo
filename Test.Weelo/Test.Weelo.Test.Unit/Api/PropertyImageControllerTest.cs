using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Weelo.Controllers;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Infrastructure.ViewModel;
using Test.Weelo.Service.Features.PropertyFeatures.Commands;
using Test.Weelo.Service.Features.PropertyImageFeatures.Commands;

namespace Test.Weelo.Test.Unit.Api
{
    public class PropertyImageControllerTest
    {
        [Test]
        public async Task CreatePost_ReturnNoContent()
        {
            PropertyImageEntity propertyImageEntity = new PropertyImageEntity() { IdPropertyImage = 1 };
            

            Mock<IMediator> mediator = new Mock<IMediator>();
            mediator.Setup(med => med.Send(It.IsAny<CreatePropertyImageCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(1);

            PropertyImageController propertyImageController = new PropertyImageController(mediator.Object);

            var result = await propertyImageController.Create(It.IsAny<CreatePropertyImageCommand>());
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
