using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mazegame.Entity;
namespace Mazegame.Control
{
    public class SellCommand : Command
    {
        public override CommandResponse Execute(ParsedInput userInput,
            Player thePlayer)
        {
            if (userInput.Arguments.Count == 0)
                return new CommandResponse("Please tell me what to sell");
            String itemLable = (String)userInput.Arguments[0];

            Item itemToSell = thePlayer.GetInventory().FindItem(itemLable);
            if (itemToSell == null)
                return new CommandResponse(itemLable + " cannot be found");


            bool isSold = thePlayer.CurrentLocation.GetInventory().AddItem(itemToSell);

            //return new CommandResponse(itemLable + " is successfully bought and added to your inventory");

            if (isSold)
            {
                thePlayer.GetInventory().RemoveItem(itemLable);
                thePlayer.GetInventory().GetMoney().Add(itemToSell.Worth);
                return new CommandResponse(itemLable + " is successfully sold and money is added to your inventory");
            }

            else
                return new CommandResponse(itemLable + " can't be sold due to weight restriction");
        }
    }
}

