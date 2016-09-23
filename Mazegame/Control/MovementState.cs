using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mazegame.Entity;

namespace Mazegame.Control
{
    public class MovementState : CommandState
    {
        public MovementState() : base()
        {
            AvailableCommands.Add("go", new MoveCommand());
            AvailableCommands.Add("quit", new QuitCommand());
            AvailableCommands.Add("get", new GetItem());
            AvailableCommands.Add("move", new MoveCommand());
            AvailableCommands.Add("look", new LookCommand());
            AvailableCommands.Add("list", new ListItem());
            
        }

        public override CommandState Update(Player thePlayer)
        {
            if (thePlayer.CurrentLocation is Shop)
            {
                return new CommerceState();
                
            }
            else if (thePlayer.CurrentLocation.GetNonPlayerCharacterCollection().HasHostile())
            {
                return new CombatState();
            }
            else
            {

                return this;
            }
        }
    }
}
