using AutoMapper;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Persistence;

namespace Test.Weelo.Service.Features.OwnerFeatures.Commands
{
    public class CreateOwnerCommand: IRequest<OwnerEntity>
    {
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Photho { get; set; }

        public DateTime Birthday { get; set; }

        public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, OwnerEntity>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CreateOwnerCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async  Task<OwnerEntity> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
            {
                OwnerEntity owner = _mapper.Map<OwnerEntity>(request);
                _context.Owner.Add(owner);
                await _context.SaveChangesAsync();

                return owner;
            }
        }
    }
}
