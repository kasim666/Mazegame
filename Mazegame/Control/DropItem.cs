using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    class DropItem : Command
    {
        public override CommandResponse Execute(ParsedInput userInput, Player thePlayer)
        {
            if (userInput.Arguments.Count == 0)
                return new CommandResponse("Please tell me what to drop");
            String itemLabel = (String)userInput.Arguments[0];

            Item itemToDrop = thePlayer.GetInventory().FindItem(itemLabel);
            if (itemToDrop == null)
                return new CommandResponse(itemLabel + " cannot be found");
            bool isDroped = thePlayer.GetInventory().AddItem(itemToDrop);
            if (isDroped)
            {
                thePlayer.GetInventory().RemoveItem(itemLabel);
                thePlayer.CurrentLocation.GetInventory().AddItem(itemToDrop);
                return new CommandResponse(itemLabel + " is successfully successfully dropped.");
            }
            return new CommandResponse(itemLabel + " not found!");
        }
    }
}
