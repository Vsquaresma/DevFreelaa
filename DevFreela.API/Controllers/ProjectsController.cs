using DevFreela.Application.Commands.CompleteProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.InsertComment;
using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        //private readonly FreelanceTotalCostConfig _config;
        //private readonly IConfigService _configService;

        private readonly IMediator _mediator;
        public ProjectsController(IMediator mediator)
        {            
            _mediator = mediator;
        }

        //public ProjectsController(
        //    IOptions<FreelanceTotalCostConfig> options,
        //    IConfigService configService)
        //{

        //    _config = options.Value;
        //    _configService = configService;
        //}

        // GET api/projects?search=crm
        [HttpGet]
        //public async IActionResult Get(string search = "", int page = 0, int size = 3)
        public async Task<IActionResult> Get(string search = "", int page = 0, int size = 3)
        {
            //   var result = _service.GetAll(search);

            var query = new GetAllProjectsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);

            //return Ok(_configService.GetValue());
        }

        // GET api/projects/1234
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var result = _service.GetById(id);

            var result = await _mediator.Send(new GetProjectByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // POST api/Projects
        [HttpPost]
        public async Task<IActionResult> Post(InsertProjectCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        // PUT api/projects/1234
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProjectCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // DELETE api/projects/1234
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var result = _service.Delete(id);
            var result = await _mediator.Send(new DeleteProjectCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // PUT api/projects/1234/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var result = await _mediator.Send(new StartProjectCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // PUT api/projects/1234/complete
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var result = await _mediator.Send(new CompleteProjectCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // POST api/projects/1234/comments
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, InsertCommentCommand command)
        {
            //var result = _service.InsertComment(id, model);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
