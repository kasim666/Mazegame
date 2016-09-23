using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mazegame.Entity;

namespace Mazegame.Control
{
    public class CommerceState : CommandState
    {
        public CommerceState()
            : base()
        {
            AvailableCommands.Add("go", new MoveCommand());
            AvailableCommands.Add("buy", new BuyCommand());
            AvailableCommands.Add("sell", new SellCommand());
            AvailableCommands.Add("move", new MoveCommand());
            AvailableCommands.Add("look", new LookCommand());
        }

        public override CommandState Update(Player thePlayer)
        {
            if (thePlayer.CurrentLocation is Shop)
            {
                return this;
            }
            else if (thePlayer.CurrentLocation.GetNonPlayerCharacterCollection().HasHostile())
            {
                return new CombatState();
            }
            else
            {

                return new MovementState();
            }

        }
    }
}

