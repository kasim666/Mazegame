using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mazegame.Entity;
namespace Mazegame.Control
{
    public class BuyCommand : Command
    {
        public override CommandResponse Execute(ParsedInput userInput,
            Player thePlayer)
        {
            if (userInput.Arguments.Count == 0)
                return new CommandResponse("Please tell me what to buy");
            String itemLable = (String)userInput.Arguments[0];

            Item itemToBuy = thePlayer.CurrentLocation.GetInventory().FindItem(itemLable);
            if (itemToBuy == null)
                return new CommandResponse(itemLable + " cannot be found");

            if (thePlayer.GetInventory().GetMoney().GetTotal() >= itemToBuy.Worth)
            {
                bool isBought = thePlayer.GetInventory().AddItem(itemToBuy);

                //return new CommandResponse(itemLable + " is successfully bought and added to your inventory");

                if (isBought)
                {
                    thePlayer.CurrentLocation.GetInventory().RemoveItem(itemLable);
                    thePlayer.GetInventory().GetMoney().Subtract(itemToBuy.Worth);
                    return new CommandResponse(itemLable + " is successfully bought and added to your inventory");
                }
                else
                    return new CommandResponse(itemLable + " can't be added due to weight restriction");
               
            }
            return new CommandResponse(itemLable + " can't be bought as not enough money");
        }
    }
}
