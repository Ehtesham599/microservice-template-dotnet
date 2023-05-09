using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AppCore.Application.User.Queries.Get;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var response = await _mediator.Send(new GetRequest());

            return Ok(response);
        }
    }
}
