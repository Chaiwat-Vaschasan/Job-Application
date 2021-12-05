using APPLICATION.IdentityServer.Commands;
using DOMAIN.Models.IdentityServer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentityServerController : ControllerBase
    {

        #region Inject
        private readonly IMediator mediator;

        public IdentityServerController(IMediator mediator) 
        {
            this.mediator = mediator;
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> AddClient(ClientModel client) 
        {
            var requrest = new ClientCommand() { ClientModel = client };
            var response = await mediator.Send(requrest);
            return new OkObjectResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddScope(ApiScopeModel scope)
        {
            var requrest = new ScopeCommand() { ScopeModel = scope };
            var response = await mediator.Send(requrest);
            return new OkObjectResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddResource(ApiResourceModel resource)
        {
            var requrest = new ResourceCommand() { ResourceModel = resource };
            var response = await mediator.Send(requrest);
            return new OkObjectResult(response);
        }

    }
}
