using Mazegame.Entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mazegame.Control
{
    public class CommandHandler
    {
        private CommandState availableCommands;

        public CommandHandler()
        {
            availableCommands = new MovementState();
        }

        public CommandResponse ProcessTurn(String userInput, Player thePlayer)
        {
            availableCommands = availableCommands.Update(thePlayer);
            ParsedInput validInput = parse(userInput);

            Command theCommand = availableCommands.GetCommand(validInput.Command);
            if (theCommand == null)
                return new CommandResponse("Not a valid command");
            return theCommand.Execute(validInput, thePlayer);
        }

        private ParsedInput parse(String userInput)
        {
            Parser theParser = new Parser(availableCommands.GetLabels());
            return theParser.Parse(userInput);
        }
    }
}

/*
namespace Mazegame.Control
{
    public class CommandHandler
    {
        private Hashtable availableCommands;

       private Parser theParser;

        public CommandHandler()
        {
            availableCommands = new Hashtable();
            SetupCommands();
            theParser = new Parser(new ArrayList(availableCommands.Keys));
        }

        private void SetupCommands()
        {
            availableCommands.Add("go", new MoveCommand());
            availableCommands.Add("quit", new QuitCommand());
            availableCommands.Add("move", new MoveCommand());
            availableCommands.Add("look", new LookCommand());
            availableCommands.Add("get", new GetItem());
            availableCommands.Add("listitem", new ListItem());
            availableCommands.Add("drop", new DropItem());
        }


        public CommandResponse ProcessTurn(String userInput, Player thePlayer)
        {
            ParsedInput validInput = theParser.Parse(userInput);
                Command theCommand = (Command)availableCommands[validInput.Command];
                if(theCommand != null)
                return theCommand.Execute(validInput, thePlayer);
            else {
                return new CommandResponse("Not a valid command. Here are some suggestions: go, quit, move, look, get, listitem, drop");
            }
        }
    }
}
*/
