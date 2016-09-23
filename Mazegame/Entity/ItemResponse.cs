using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Control;

namespace Mazegame.Entity
{
    class ItemResponse
    {
        private bool finishedGame;
        private string message;

        public ItemResponse(string message)
        {
            Message = message;
            FinishedGame = false;
        }

        public ItemResponse(string message, bool quitFlag)
        {
            Message = message;
            FinishedGame = quitFlag;
        }

        public bool FinishedGame
        {
            get { return finishedGame; }
            set { finishedGame = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
