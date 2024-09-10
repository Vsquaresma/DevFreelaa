using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    //var query = new GetAllSkillsQuery() _context.Skills.ToList();

        //    ////TODO: Criar um model para os skills

        //    //return Ok(skills);
        //}

        //[HttpPost]
        //public IActionResult Post(CreateSkillInputModel model)
        //{
        //    var skill = new Skill(model.Description);

        //    _context.Skills.Add(skill);
        //    _context.SaveChanges();

        //    return NoContent();
        //}
    }
}
