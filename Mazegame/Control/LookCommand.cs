using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class LookCommand : Command
    {
        private CommandResponse response;

        public override CommandResponse Execute(ParsedInput userInput, Player thePlayer)
        {
            response = new CommandResponse("Can't find that to look at here!");
            if (userInput.Arguments.Count == 0)
            {
                response.Message = thePlayer.CurrentLocation.ToString();
                return response;
            }
            foreach (string argument in userInput.Arguments)
            {
                if (thePlayer.CurrentLocation.ContainsExit(argument))
                {
                    Exit theExit = thePlayer.CurrentLocation.GetExit(argument);
                    return new CommandResponse(theExit.Description);
                }
            }
            return response;
        }
    }
}

