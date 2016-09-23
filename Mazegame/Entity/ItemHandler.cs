using Mazegame.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using Mazegame.Control;
namespace Mazegame.Entity
{
    class ItemHandler
    {
        private Hashtable availableCommands;
        private Parser theParser;

        public ItemHandler()
        {
            availableCommands = new Hashtable();
            SetupCommands();
            theParser = new Parser(new ArrayList(availableCommands.Keys));
        }

        private void SetupCommands()
        {
            availableCommands.Add("add", new PickItem());
            availableCommands.Add("show", new ListItem());
            availableCommands.Add("remove", new DropItem());
        }

        public ItemResponse ProcessTurn(String userInput, Player thePlayer)
        {
            ParsedInput validInput = theParser.Parse(userInput);
            try
            {
                Item theCommand = (Item)availableCommands[validInput.Command];

                return theCommand.Execute(validInput, thePlayer);
            }
            catch (KeyNotFoundException)
            {
                return new ItemResponse("Not a valid command");
            }
        }
    }
}
