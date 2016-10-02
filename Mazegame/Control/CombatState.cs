using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class CombatState : CommandState
    {
        public CombatState()
            : base()
        {
            AvailableCommands.Add("attack", new AttackCommand());
            AvailableCommands.Add("look", new LookCommand());
            AvailableCommands.Add("flee", new FleeCommand());
            
        }

        public override CommandState Update(Player thePlayer)
        {

            if (thePlayer.CurrentLocation.GetNonPlayerCharacterCollection().HasHostile())
            {
                return this;
            }

            else if (thePlayer.CurrentLocation is Shop)
            {
                
                return new CommerceState();
            }

            else
            {

                return new MovementState();
            }
            
        }
    }
}
