
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
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
            var id = _mediator.Send(createUserCommand);
            return CreatedAtAction(nameof(GetById), new { id = id}, createUserCommand);
        }

        
        // api/users/login
        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if(loginUserViewModel == null)
            {
                return BadRequest();
            }

            return Ok(loginUserViewModel);
        } 
        
    }
}
