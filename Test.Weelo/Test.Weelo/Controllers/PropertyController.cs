using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using Test.Weelo.Infrastructure.ViewModel;
using Test.Weelo.Service.Features.PropertyFeatures.Commands;

namespace Test.Weelo.Controllers
{
    [ApiVersion("1.0")]
    public class PropertyController : BaseApiController
    {
        private readonly IMapper _mapper;
        public PropertyController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerResponse(200, Type = typeof(PropertyModel))]
        public async Task<IActionResult> Create(CreatePropertyCommand command)
        {
            PropertyModel property = _mapper.Map<PropertyModel>( await Mediator.Send( command ) );
            return Ok(property);
        }

        [HttpPut("{Id}/price/{Price}")]
        [SwaggerResponse(204)]
        public async Task<IActionResult> UpdatePrice(int Id, double Price)
        {
            UpdatePricePropertyCommand command = new UpdatePricePropertyCommand() { Id = Id, Price = Price };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
