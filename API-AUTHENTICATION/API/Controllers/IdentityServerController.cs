using APPLICATION.IdentitySrver.Commands;
using DOMAIN.Models.IdentityServer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
