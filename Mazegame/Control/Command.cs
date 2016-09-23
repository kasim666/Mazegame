using Mazegame.Entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mazegame.Control
{
    public abstract class Command
    {
        public abstract CommandResponse Execute(ParsedInput userInput,
            Player thePlayer);
    }
}

