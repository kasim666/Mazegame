using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    class UnequipItem : Command
    {
        public override CommandResponse Execute(ParsedInput userInput, Player thePlayer)
        {
            if (userInput.Arguments.Count == 0)
                return new CommandResponse("Please tell me what to unequip");
            String itemLable = (String)userInput.Arguments[0];

            Item itemTounEquip = thePlayer.GetInventory().FindItem(itemLable);
            if (itemTounEquip == null)
            {
                return new CommandResponse(itemLable + " cannot be found");
                // thePlayer.MShield = null;
                // Console.Write(itemToEquip is Shield + "  state =  " + thePlayer.getShield());
            }
            bool unequiped = false;

            if ((itemTounEquip is Shield) && thePlayer.m_Shield != null)
            {
                thePlayer.m_Shield = null;
                thePlayer.GetInventory().AddItem(itemTounEquip);
                unequiped = true;
            }
            else if ((itemTounEquip is Armor) && thePlayer.m_Armor != null)
            {
                thePlayer.m_Armor = null;
                thePlayer.GetInventory().AddItem(itemTounEquip);
                unequiped = true;

            }
            else if ((itemTounEquip is Weapon) && thePlayer.m_Weapon != null)
            {
                thePlayer.m_Weapon = null;
                thePlayer.GetInventory().AddItem(itemTounEquip);
                unequiped = true;
            }

            if (unequiped)
                return new CommandResponse(itemLable + " is successfully unequipped");

            return new CommandResponse("No item is unequipped");
        }
    }
}
