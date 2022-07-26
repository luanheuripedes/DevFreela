
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController:ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //api/users/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);

            var user = await _mediator.Send(query);
            return Ok();
        }

        // api/users/
        
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserCommand createUserCommand)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.SelectMany(ms => ms.Value.Errors).Select(e=>e.ErrorMessage).ToList();
                return BadRequest(messages);
            }
            var id = _mediator.Send(createUserCommand);
            return CreatedAtAction(nameof(GetById), new { id = id}, createUserCommand);
        }

        /*
        // api/users/1/login
        [HttpPut("{id}/login")]
        public IActionResult Login( int id, [FromBody] LoginModel login)
        {
            return NoContent();
        } 
        */
    }
}
