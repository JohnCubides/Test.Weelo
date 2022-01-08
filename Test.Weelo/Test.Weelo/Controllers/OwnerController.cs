using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Annotations;
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
        public async Task<IActionResult> Create(CreateOwnerCommand command)
        {
            OwnerModel owner = _mapper.Map<OwnerModel>(await Mediator.Send(command)); 
            return Ok(owner);
        }
    }
}
