using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    class ListItem : Command
    {
        public override CommandResponse Execute(ParsedInput userInput, Player thePlayer)
        {
            return new CommandResponse(thePlayer.CurrentLocation.GetInventory().ToString());
        }
    }
}
