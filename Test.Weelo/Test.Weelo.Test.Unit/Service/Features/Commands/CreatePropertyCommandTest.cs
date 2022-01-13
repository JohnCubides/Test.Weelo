using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Persistence;
using Test.Weelo.Service.Features.PropertyFeatures.Commands;
using static Test.Weelo.Service.Features.PropertyFeatures.Commands.CreatePropertyCommand;

namespace Test.Weelo.Test.Unit.Service.Features.Commands
{
    public class CreatePropertyCommandTest
    {
        [Test]
        public async Task CanCreateProperty()
        {

            PropertyEntity propertyResponse = new PropertyEntity() { IdProperty = 1, Name = "prb" };
            Mock<IApplicationDbContext> context = new Mock<IApplicationDbContext>();
            Mock<IMapper> mapper = new Mock<IMapper>();
            context.Setup(set => set.Property.Add(It.IsAny<PropertyEntity>()));
            mapper.Setup(set => set.Map<PropertyEntity>(It.IsAny<CreatePropertyCommand>())).Returns(propertyResponse);

            CreatePropertyCommandHandler handler = new CreatePropertyCommandHandler(context.Object, mapper.Object);
            var x = await handler.Handle(It.IsAny<CreatePropertyCommand>(), It.IsAny<CancellationToken>());

            Assert.IsInstanceOf<PropertyEntity>(x);

        }
    }
}
