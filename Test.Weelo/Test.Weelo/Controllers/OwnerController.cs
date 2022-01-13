using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using Test.Weelo.Infrastructure.ViewModel;
using Test.Weelo.Service.Features.OwnerFeatures.Commands;

namespace Test.Weelo.Controllers
{
    
    [ApiVersion("1.0")]
    public class OwnerController : BaseApiController
    {
        private readonly IMapper _mapper;
        public OwnerController(IMediator mediator, IMapper mapper) : base(mediator) 
        {
            _mapper = mapper;
        }


        [HttpPost]
        [SwaggerResponse(200, Type = typeof(OwnerModel))]
        [SwaggerResponse(400, Type = typeof(string))]
        [SwaggerOperation(Summary = "Create Owner")]
        public async Task<IActionResult> Create(CreateOwnerCommand command)
        {
            try
            {
                OwnerModel owner = _mapper.Map<OwnerModel>(await Mediator.Send(command));
                return Ok(owner);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
