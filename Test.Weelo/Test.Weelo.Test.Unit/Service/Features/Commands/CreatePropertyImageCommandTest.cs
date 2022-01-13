using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Persistence;
using Test.Weelo.Service.Features.PropertyImageFeatures.Commands;
using static Test.Weelo.Service.Features.PropertyImageFeatures.Commands.CreatePropertyImageCommand;

namespace Test.Weelo.Test.Unit.Service.Features.Commands
{
    public class CreatePropertyImageCommandTest
    {
        [Test]
        public async Task CanCreateProperty()
        {

            PropertyImageEntity propertyImageResponse = new PropertyImageEntity() { IdPropertyImage = 1 };
            List<string> files = new List<string>() { "uno", "dos" };
            CreatePropertyImageCommand command = new CreatePropertyImageCommand() { Files = files };
            Mock<IApplicationDbContext> context = new Mock<IApplicationDbContext>();
            Mock<IMapper> mapper = new Mock<IMapper>();
            context.Setup(set => set.PropertyImage.Add(It.IsAny<PropertyImageEntity>()));
            mapper.Setup(set => set.Map<PropertyImageEntity>(It.IsAny<CreatePropertyImageCommand>())).Returns(propertyImageResponse);

            CreatePropertyImageCommandHandler handler = new CreatePropertyImageCommandHandler(context.Object, mapper.Object);
            var x = await handler.Handle(command, It.IsAny<CancellationToken>());

            Assert.IsInstanceOf<int>(x);

        }
    }
}
