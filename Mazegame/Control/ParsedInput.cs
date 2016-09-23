using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Control
{
    public class ParsedInput
    {
        private string command;
        private ArrayList arguments;

        public ParsedInput()
        {
            arguments = new ArrayList();
            command = "";
        }

        public ParsedInput(string command, ArrayList arguments)
        {
            this.command = command;
            this.arguments = arguments;
        }

        public string Command
        {
            get { return command; }
            set { command = value; }
        }

        public ArrayList Arguments
        {
            get { return arguments; }
            set { arguments = value; }
        }
    }
}
