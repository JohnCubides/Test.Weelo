using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using Test.Weelo.Controllers;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Persistence;
using Test.Weelo.Service.Features.OwnerFeatures.Commands;
using static Test.Weelo.Service.Features.OwnerFeatures.Commands.CreateOwnerCommand;

namespace Test.Weelo.Test.Unit.Service.Features.Commands
{
    public class CreateOwnerCommandTest
    {
        [Test]
        public async Task CanCreateOwner()
        {

            OwnerEntity ownerResponse = new OwnerEntity() { IdOwner = 1, Name="prb"};
            Mock<IApplicationDbContext> context = new Mock<IApplicationDbContext>();
            Mock <IMapper> mapper = new Mock<IMapper>();
            context.Setup(set => set.Owner.Add(It.IsAny<OwnerEntity>()));
            mapper.Setup(set => set.Map<OwnerEntity>(It.IsAny<CreateOwnerCommand>())).Returns(ownerResponse);

            CreateOwnerCommandHandler handler = new CreateOwnerCommandHandler(context.Object, mapper.Object);
            var x = await handler.Handle(It.IsAny<CreateOwnerCommand>(), It.IsAny<CancellationToken>());

            Assert.IsInstanceOf<OwnerEntity>(x);

        }
    }
}
