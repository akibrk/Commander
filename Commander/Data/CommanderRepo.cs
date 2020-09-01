using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class CommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public CommanderRepo(CommanderContext context)
        {
            _context = context; 
        }

        public void CreateCommand(Command command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _context.Commands.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _context.Commands.Remove(command);
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Command> GetCommands()
        {
            return _context.Commands.ToList();
        }

        public void PatchCommand(Command command)
        {
            throw new NotImplementedException();    
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges())>= 0;
        }
        public void UpdateCommand(Command command)
        {
            _context.Commands.Update(command);
        }
    }
}
