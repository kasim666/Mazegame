using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    class GetItem : Command
    {
        public override CommandResponse Execute(ParsedInput userInput, Player thePlayer)
        {
            if (userInput.Arguments.Count == 0)
                return new CommandResponse("Please tell me what to get");
            String itemLable = (String)userInput.Arguments[0];

            Item itemToGet = thePlayer.CurrentLocation.GetInventory().FindItem(itemLable);
            if (itemToGet == null)
                return new CommandResponse(itemLable + " cannot be found");
            bool isAdded = thePlayer.GetInventory().AddItem(itemToGet);
            if (isAdded)
            {
                thePlayer.CurrentLocation.GetInventory().RemoveItem(itemLable);
                return new CommandResponse(itemLable + " is successfully added to your inventory");
            }
            return new CommandResponse(itemLable + " can't be added due to weight restriction");
        }
    }
}
