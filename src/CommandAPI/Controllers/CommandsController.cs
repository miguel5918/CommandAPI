using System.Collections.Generic;
using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly ICommandAPIRepo _repository;
        public CommandsController(ICommandAPIRepo repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var CommandItems = _repository.GetAllCommands();
            return Ok(CommandItems);
        }

        [HttpGet ("{Id}")]
        public ActionResult<IEnumerable<Command>> GetCommandById(int Id)
        {
            var CommandItems = _repository.GetCommandById(Id);
            if (CommandItems==null)
            {
                return NotFound();
            }
            return Ok(CommandItems);
        }
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "this", "is", "hard", "coded" };
        //}
    }
}