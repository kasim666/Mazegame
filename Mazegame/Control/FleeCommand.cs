using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;
namespace Mazegame.Control
{
    public class FleeCommand : Command
    {
        public override CommandResponse Execute(ParsedInput userInput,
            Player thePlayer)
        {
            thePlayer.CurrentLocation = thePlayer.CurrentLocation.GetRandomExit().Destination;
            return new CommandResponse("You successfully fled from the enemy and are in some safe location" + thePlayer.CurrentLocation.Description);
        }
        
    }
}
