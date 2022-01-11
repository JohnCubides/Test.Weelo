using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Persistence;

namespace Test.Weelo.Service.Features.PropertyImageFeatures.Commands
{
    public class CreatePropertyImageCommand: IRequest<int>
    {
        [Required]
        public int IdProperty { get; set; }

        [Required]
        public List<string> Files { get; set; }

        [JsonIgnore]
        public bool Enabled { get; set; } = true;

        public class CreatePropertyImageCommandHandler : IRequestHandler<CreatePropertyImageCommand, int>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CreatePropertyImageCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreatePropertyImageCommand request, CancellationToken cancellationToken)
            {
                var files = request.Files;
                foreach(string file in files)
                {
                    PropertyImageEntity propertyImage = _mapper.Map<PropertyImageEntity>(request);
                    propertyImage.File = file;
                    _context.PropertyImage.Add(propertyImage);
                    await _context.SaveChangesAsync();
                }
                return 1;
            }
        }
    }
}
