using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using Test.Weelo.Domain.Dto.PropertyDto;
using Test.Weelo.Infrastructure.ViewModel;
using Test.Weelo.Service.Features.PropertyFeatures.Commands;
using Test.Weelo.Service.Features.PropertyFeatures.Queries;

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
        [SwaggerResponse(400, Type = typeof(string))]
        [SwaggerOperation(Summary = "Create Property Building ")]
        public async Task<IActionResult> Create(CreatePropertyCommand command)
        {
            try
            {
                PropertyModel property = _mapper.Map<PropertyModel>(await Mediator.Send(command));
                return Ok(property);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/price/{price}")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400, Type=typeof(string))]
        [SwaggerOperation(Summary = "Change Price Property")]
        public async Task<IActionResult> UpdatePrice(int id, double price)
        {
            try
            {
                UpdatePricePropertyCommand command = new UpdatePricePropertyCommand() { Id = id, Price = price };
                await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400, Type = typeof(string))]
        [SwaggerOperation(Summary = "Update Property")]
        public async Task<IActionResult> Update(int id, UpdatePropertyCommand command)
        {
            try
            {
                command.IdProperty = id;
                await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("filters")]
        [SwaggerResponse(200, Type = typeof(PropertyFiltersResponseDto))]
        [SwaggerOperation(Summary = "List property  with filters and pagination")]
        public async Task<IActionResult> GetAll(GetAllPropertyFiltersQuery query)
        {
            try
            {
                PropertyFiltersResponseDto propertiesResponse = await Mediator.Send(query);
                return Ok(propertiesResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
