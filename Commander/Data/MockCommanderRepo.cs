using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, Description = "This is how", Name = "ht", Platform = "win" };
        }

        public IEnumerable<Command> GetCommands()
        {
            return new List<Command>
            {
                new Command{ Id = 0, Description = "This is how", Name = "ht", Platform = "win" },
                new Command{ Id = 1, Description = "Directory", Name = "dr", Platform = "win" },
                new Command{ Id = 2, Description = "Open file", Name = "op", Platform = "win" },

            };

        }

        public void PatchCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
