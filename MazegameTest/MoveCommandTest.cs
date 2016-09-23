using System;
using System.Collections;
using Mazegame.Control;
using Mazegame.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazegameTest
{
    [TestClass]
    public class MoveCommandTest
    {
        private ParsedInput playerInput;
        private Player thePlayer;
        private CommandHandler handler;
        private MoveCommand move;
        private Location t127;
        private Location gregsoffice;

        [TestInitialize]
        public void Init()
        {
            playerInput = new ParsedInput("move", new ArrayList());
            thePlayer = new Player("greg");
            t127 = new Location("a lecture theatre", "T127");
            gregsoffice = new Location("a spinning vortex of terror", "Greg's Office");
            t127.AddExit("south", new Exit("you see a mound of paper to the south", gregsoffice));
            gregsoffice.AddExit("north", new Exit("you see a bleak place to the north", t127));
            thePlayer.CurrentLocation = t127;
            handler = new CommandHandler();
            move = new MoveCommand();
        }

        [TestMethod]
        public void TestMoveNowhere()
        {
            Assert.AreSame(t127, thePlayer.CurrentLocation);
            // test move command no arguments
            CommandResponse response = move.Execute(playerInput, thePlayer);
            Assert.IsFalse(response.FinishedGame);
            Assert.IsTrue(response.Message.Contains("tell me where"));
            Assert.AreSame(t127, thePlayer.CurrentLocation);
        }


        [TestMethod]
        public void TestMoveNoExit()
        {
            playerInput.Arguments = new ArrayList(new string[] { "west" });
            CommandResponse response = move.Execute(playerInput, thePlayer);
            Assert.IsFalse(response.FinishedGame);
            Assert.IsTrue(response.Message.Contains("no exit there"));
            Assert.AreSame(t127, thePlayer.CurrentLocation);
        }

        [TestMethod]
        public void TestTakeExit()
        {
            playerInput.Arguments = new ArrayList(new string[] { "south" });
            CommandResponse response = move.Execute(playerInput, thePlayer);
            Assert.IsFalse(response.FinishedGame);
            Assert.IsTrue(response.Message.Contains(gregsoffice.Description));
            Assert.AreSame(gregsoffice, thePlayer.CurrentLocation);
        }

        [TestMethod]
        public void TestMoveHandler()
        {
            // test move command no arguments
            CommandResponse response = handler.ProcessTurn("move to the south", thePlayer);
            Assert.IsFalse(response.FinishedGame);
            Assert.IsTrue(response.Message.Contains(gregsoffice.Description));
            Assert.AreSame(gregsoffice, thePlayer.CurrentLocation);
        }
    }
}
