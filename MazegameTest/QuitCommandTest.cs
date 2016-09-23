using System;
using System.Collections;
using Mazegame.Control;
using Mazegame.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazegameTest
{
    [TestClass]
    public class QuitCommandTest
    {
        private ParsedInput playerInput;
        private Player thePlayer;
        private CommandHandler handler;
        private QuitCommand quit;

        [TestInitialize]
        public void Init()
        {
            playerInput = new ParsedInput("quit", new ArrayList());
            thePlayer = new Player("greg");
            handler = new CommandHandler();
            quit = new QuitCommand();
        }

        [TestMethod]
        public void TestQuit()
        {
            // test quit command no arguments
            CommandResponse response = quit.Execute(playerInput, thePlayer);
            Assert.IsTrue(response.FinishedGame);
            Assert.IsTrue(response.Message.Contains("Goodbye"));

            // test quit command >0 arguments
            playerInput.Arguments = new ArrayList(new string[] { "this", "game" });
            response = quit.Execute(playerInput, thePlayer);
            Assert.IsTrue(response.FinishedGame);
            Assert.IsTrue(response.Message.Contains("Goodbye"));
        }

        [TestMethod]
        public void TestQuitHandler()
        {
            // test quit command no arguments
            CommandResponse response = handler.ProcessTurn("quit", thePlayer);
            Assert.IsTrue(response.FinishedGame);
            Assert.IsTrue(response.Message.Contains("Goodbye"));

            // test quit command >0 arguments
            response = handler.ProcessTurn("quit this game", thePlayer);
            Assert.IsTrue(response.FinishedGame);
            Assert.IsTrue(response.Message.Contains("Goodbye"));
        }
    }
}

