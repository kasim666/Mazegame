using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public abstract class CommandState
    {
        private Hashtable availableCommands;

        public CommandState()
        {
            AvailableCommands = new Hashtable();
        }

        protected Hashtable AvailableCommands
        {
            get { return availableCommands; }
            set { availableCommands = value; }
        }

        public abstract CommandState Update(Player thePlayer);

        public Command GetCommand(string commandLabel)
        {
            try
            {
                return (Command)AvailableCommands[commandLabel];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public ArrayList GetLabels()
        {
            return new ArrayList(availableCommands.Keys);
        }
    }
}
