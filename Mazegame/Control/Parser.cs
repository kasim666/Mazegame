using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Control
{
    public class Parser
    {
        private ArrayList dropWords;
        private ArrayList validCommands;

        public Parser(ArrayList validCommands)
        {
            dropWords = new ArrayList(new string[]{"in","an","and",
                "the","this", "to"});
            this.validCommands = validCommands;
        }

        public ParsedInput Parse(String rawInput)
        {
            ParsedInput parsedInput = new ParsedInput();
            String lowercaseInput = rawInput.ToLower();
            ArrayList stringTokens = new ArrayList(lowercaseInput.Split());

            foreach (string token in stringTokens)
            {

                if (validCommands.Contains(token))
                {
                    parsedInput.Command = token;
                }
                else if (!dropWords.Contains(token))
                    parsedInput.Arguments.Add(token);
            }
            return parsedInput;
        }

    }
}
