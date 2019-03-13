using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadCache.App.Features.User;

namespace ReadCache.App.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet, Route("{userId}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var getUser = new GetUser.Query
            {
                Id = userId
            };

            var result = await _mediator.Send(getUser);

            return Ok(result);

        }

        public async Task<IActionResult> Post([FromBody] CreateUser.Command user)
        {
            var result = await _mediator.Send(user);

            return Ok(result);
        }
    }
}