using DevFreela.API.Models;
using DevFreela.API.Models.ModelsProject;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        public readonly OpeningTimeOption _option;
        public readonly IProjectServices _projectServices;


        public ProjectsController(IOptions<OpeningTimeOption> option, ExampleClass exampleClass)
        {
            exampleClass.Name = "Atualizada no projectController";
            _option = option.Value;
        }


        //api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            //Buscar todos os projetos ou filtrar
            return Ok();
        }

        // api/projects/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            //Buscar o projeto por id

            return Ok();

            // return NotFound() quando não encontranda 
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            // return BadRequest() - algum campo que foi enviado não esta de acordo com o que o cliente pode receber

            if (createProject.Title.Length > 50)
            {
                return BadRequest();
            }

            //Cadastrar o projeto 
            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }

        // api/projects/2
        [HttpPut("id")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProjectModel)
        {
            if(updateProjectModel.Description.Length > 200)
            {
                return BadRequest();
            }

            //Atualizo o projeto
            return NoContent();
        }

        // api/projects/3
        [HttpDelete("id")]
        public IActionResult Put(int id)
        {

            //Buscar, se não existir, retorna NotFound


            //Remover
            return NoContent();
        }

        // api/projectes/1/comments POST
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment)
        {
            return NoContent();
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }
    }
}
