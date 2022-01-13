using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Persistence;
using Test.Weelo.Service.Exceptions;

namespace Test.Weelo.Service.Features.PropertyFeatures.Commands
{
    public class UpdatePropertyCommand: IRequest<int>
    {
        [JsonIgnore]
        public int IdProperty { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public double Price { get; set; }

        public string CodeInternal { get; set; }

        public int Year { get; set; }
        
        [Required]
        public int IdOwner { get; set; }

        public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, int>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public UpdatePropertyCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<int> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    PropertyEntity property = _mapper.Map<PropertyEntity>(request);
                    _context.Property.Update(property);
                    await _context.SaveChangesAsync();

                    return property.IdProperty;
                }
                catch(Exception ex)
                {
                    if(ex.InnerException != null)
                        throw new ApiException(ex.InnerException.Message);

                    throw new ApiException(ex.Message);
                }
            }
        }


    }
}
