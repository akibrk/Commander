using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Commander.Profiles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Controllers.API
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController: ControllerBase
    {
        private readonly ICommanderRepo _command_repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo commanderRepo, IMapper mapper)
        {
            _command_repo = commanderRepo;
            _mapper = mapper;
        }

        // api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var data = _command_repo.GetCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(data));
        }

        // api/commands
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandWriteDTO cmd)
        {
            var commandModel = _mapper.Map<Command>(cmd);

            _command_repo.CreateCommand(commandModel);
            _command_repo.SaveChanges(); // synchrounous save

            var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDTO.Id }, commandReadDTO);
        }

        // api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult <CommandReadDTO> GetCommandById(int id)
        {
            var data = _command_repo.GetCommandById(id);

            if(data == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<CommandReadDTO>(data));
        }

        [HttpPut("{id}", Name = "UpdateCommand")]
        public ActionResult UpdateCommand(int id, CommandWriteDTO commandUpdateDTO)
        {
            var commandModel = _command_repo.GetCommandById(id);

            if (commandModel == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDTO, commandModel);
            _command_repo.UpdateCommand(commandModel);
            _command_repo.SaveChanges();
 
            return NoContent();
            
        }

        //// api/commands/{id}
        //[HttpPatch("{id}", Name = "PartialCommandUpdate")]
        //public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandWriteDTO> patchDocument)
        //{
        //    var commandModel = _command_repo.GetCommandById(id);

        //    if (commandModel == null)
        //    {
        //        return NotFound();
        //    }

            

        //    return NoContent();

        //}

        // api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommandById(int id)
        {
            var commandModel = _command_repo.GetCommandById(id);

            if (commandModel == null)
            {
                return NotFound();
            }

            _command_repo.DeleteCommand(commandModel);

            return NoContent();
        }

    }
}
