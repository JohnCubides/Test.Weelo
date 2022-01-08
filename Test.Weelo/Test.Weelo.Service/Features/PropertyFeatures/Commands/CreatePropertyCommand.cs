using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Persistence;

namespace Test.Weelo.Service.Features.PropertyFeatures.Commands
{
    public class CreatePropertyCommand : IRequest<PropertyEntity>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public double Price { get; set; }

        public string CodeInternal { get; set; }

        public int Year { get; set; }

        public int IdOwner { get; set; }

        public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, PropertyEntity>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CreatePropertyCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PropertyEntity> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
            {
                PropertyEntity property = _mapper.Map<PropertyEntity>(request);
                _context.Property.Add(property);
                await _context.SaveChangesAsync();

                return property;
                
            }
        }

    }
}
