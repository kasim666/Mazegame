using System;
using System.Collections;
using Mazegame.Control;
using Mazegame.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazegameTest
{
    [TestClass]
    public class LookCommandTest
    {
        private ParsedInput playerInput;
        private Player thePlayer;
        private CommandHandler handler;
        private LookCommand look;
        private Exit southExit;
        private Location t127;

        [TestInitialize]
        public void Init()
        {
            playerInput = new ParsedInput("look", new ArrayList());
            thePlayer = new Player("greg");
            t127 = new Location("a lecture theatre", "T127");
            Location gregsoffice = new Location("a spinning vortex of terror", "Greg's Office");
            southExit = new Exit("you see a mound of paper to the south", gregsoffice);
            t127.AddExit("south", southExit);
            thePlayer.CurrentLocation = t127;
            handler = new CommandHandler();
            look = new LookCommand();
        }

        [TestMethod]
        public void TestLookNowhere()
        {
            Assert.AreSame(t127, thePlayer.CurrentLocation);
            // test move command no arguments
            CommandResponse response = look.Execute(playerInput, thePlayer);
            Assert.IsFalse(response.FinishedGame);
            Assert.IsTrue(response.Message.Contains(t127.Description));
        }

        [TestMethod]
        public void TestLookNoMatch()
        {
            playerInput.Arguments = new ArrayList(new string[] { "bunyip" });
            CommandResponse response = look.Execute(playerInput, thePlayer);
            Assert.IsFalse(response.FinishedGame);
            Assert.IsTrue(response.Message.Contains("Can't find that"));
        }

        [TestMethod]
        public void TestLookExit()
        {
            playerInput.Arguments = new ArrayList(new string[] { "south" });
            CommandResponse response = look.Execute(playerInput, thePlayer);
            Assert.IsFalse(response.FinishedGame);
            Assert.IsTrue(response.Message.Contains(southExit.Description));
        }

        [TestMethod]
        public void TestMoveHandler()
        {
            // test move command no arguments
            CommandResponse response = handler.ProcessTurn("look to the south", thePlayer);
            Assert.IsFalse(response.FinishedGame);
            Assert.IsTrue(response.Message.Contains(southExit.Description));
        }
    }
}
