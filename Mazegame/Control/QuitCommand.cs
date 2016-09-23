using Mazegame.Entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mazegame.Control
{
    public class QuitCommand : Command
    {
        public override CommandResponse Execute(ParsedInput userInput, Player thePlayer)
        {
            return new CommandResponse("Thanks for playing -- Goodbye", true);
        }
    }
}
