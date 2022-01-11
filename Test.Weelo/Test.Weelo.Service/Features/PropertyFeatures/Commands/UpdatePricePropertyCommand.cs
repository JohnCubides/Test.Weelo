using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Persistence;

namespace Test.Weelo.Service.Features.PropertyFeatures.Commands
{
    public class UpdatePricePropertyCommand: IRequest<int>
    {
        public int Id { get; set; }
        public double Price { get; set; }

        public class UpdatePricePropertyCommandHandler : IRequestHandler<UpdatePricePropertyCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdatePricePropertyCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdatePricePropertyCommand request, CancellationToken cancellationToken)
            {
                PropertyEntity property = _context.Property.Where(prop => prop.IdProperty == request.Id).FirstOrDefault();
                if (property == null) return default;

                property.Price = request.Price;
                _context.Property.Update(property);
                await _context.SaveChangesAsync();
                return property.IdProperty;

            }
        }


    }
}
