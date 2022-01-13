using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using Test.Weelo.Service.Features.PropertyImageFeatures.Commands;

namespace Test.Weelo.Controllers
{
    [ApiVersion("1.0")]
    public class PropertyImageController : BaseApiController
    {
        public PropertyImageController(IMediator mediator) : base(mediator){}

        [HttpPost]
        [SwaggerResponse(201)]
        [SwaggerOperation(Summary = "Add Image from property")]
        public async Task<IActionResult> Create(CreatePropertyImageCommand command)
        {
            try
            {
                await Mediator.Send(command);
                return NoContent();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
