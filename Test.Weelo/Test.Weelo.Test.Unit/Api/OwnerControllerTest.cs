using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using Test.Weelo.Controllers;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Infrastructure.ViewModel;
using Test.Weelo.Service.Features.OwnerFeatures.Commands;

namespace Test.Weelo.Test.Unit.Api
{
    public class OwnerControllerTest
    {
        [Test]
        public async Task CreatePost_ReturnOkStatus()
        {
            OwnerModel ownerModel = new OwnerModel() { IdOwner = 1 };
            OwnerEntity ownerEntity = new OwnerEntity() { IdOwner = 1 };
            Mock<IMapper> mapper = new Mock<IMapper>();
            mapper.Setup(map => map.Map<OwnerModel>(It.IsAny<OwnerEntity>())).Returns(ownerModel);

            Mock<IMediator> mediator = new Mock<IMediator>();
            mediator.Setup(med => med.Send(It.IsAny<CreateOwnerCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(ownerEntity);

            OwnerController ownerController = new OwnerController(mediator.Object, mapper.Object);

            var result = await ownerController.Create(It.IsAny<CreateOwnerCommand>());
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
 