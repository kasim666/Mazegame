using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    class EquipItem : Command
    {
        public override CommandResponse Execute(ParsedInput userInput, Player thePlayer)
        {
            if (userInput.Arguments.Count == 0)
                return new CommandResponse("Please tell me what to equip");
            String itemLable = (String)userInput.Arguments[0];

            Item itemToEquip = thePlayer.GetInventory().FindItem(itemLable);
            if (itemToEquip == null)
            {
                return new CommandResponse(itemLable + " cannot be found");
                // thePlayer.MShield = null;
                // Console.Write(itemToEquip is Shield + "  state =  " + thePlayer.getShield());
            }
            bool equiped = false;

                if((itemToEquip is Shield) && thePlayer.m_Shield == null)
                {
                    thePlayer.m_Shield= (Shield)itemToEquip;
                  equiped = true;
                }
                else if ((itemToEquip is Armor) && thePlayer.m_Armor == null)
                 {
                 thePlayer.m_Armor = (Armor)itemToEquip;
                equiped = true;

            }
                else if  ((itemToEquip is Weapon) && thePlayer.m_Weapon == null)
                {
                    thePlayer.m_Weapon = (Weapon)itemToEquip;
                equiped = true;
            }
               
            if(equiped)
                return new CommandResponse(itemLable + " is successfully equipped");

            return new CommandResponse("This type of item is already equipped");
               
            
                
            
        }
    }
}
