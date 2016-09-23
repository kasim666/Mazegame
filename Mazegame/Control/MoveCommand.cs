using Mazegame.Entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mazegame.Control
{
    public class MoveCommand : Command
    {
        public override CommandResponse Execute(ParsedInput userInput, Player thePlayer)
        {
            if (userInput.Arguments.Count == 0)
                return new CommandResponse("Where you wanna go!!");
            String exitLabel = (String)userInput.Arguments[0];
            Exit desiredExit = thePlayer.CurrentLocation.GetExit(exitLabel);
            if (desiredExit == null)
            {
                return new CommandResponse("There is no exit there.. Trying moving someplace moveable!!");
            }
            thePlayer.CurrentLocation = desiredExit.Destination;
            return new CommandResponse("You find yourself looking at " + thePlayer.CurrentLocation);

        }
    }
}

