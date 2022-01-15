using APPLICATION.Users.Commands;
using DOMAIN.Models.Users;
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
    public class UserController : ControllerBase
    {

        #region Inject
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Registered(UserModel user)
        {
            var requrest = new RegisteredUsersCommand() { UserModel = user };
            var response = await mediator.Send(requrest);
            return new OkObjectResult(response);
        }


    }
}
