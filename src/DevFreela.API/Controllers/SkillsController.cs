using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [Authorize(Roles = "admin")]
    public class SkillsController:ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSkillsQuery();

            var skills = await _mediator.Send(query);
            return Ok(skills);
        }
    }
}
