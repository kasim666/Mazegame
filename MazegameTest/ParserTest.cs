using System;
using System.Collections;
using Mazegame.Control;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazegameTest
{
    [TestClass]
    public class ParserTest
    {
        private ArrayList commands;
        private Parser theParser;

        [TestInitialize]
        public void Init()
        {
            commands = new ArrayList(new string[] { "quit", "move" });
            theParser = new Parser(commands);
        }

        [TestMethod]
        public void TestCommandDetection()
        {
            ParsedInput userInput = theParser.Parse("quit");
            Assert.AreEqual(userInput.Command, "quit");
            userInput = theParser.Parse("move west");
            Assert.AreEqual(userInput.Command, "move");
            userInput = theParser.Parse("greg");
            Assert.AreEqual(userInput.Command, "");
        }

        [TestMethod]
        public void TestArgumentDetection()
        {
            ParsedInput userInput = theParser.Parse("quit");
            Assert.IsTrue(userInput.Arguments.Count == 0);
            userInput = theParser.Parse("move west");
            Assert.IsTrue(userInput.Arguments.Count == 1);
            userInput = theParser.Parse("move to the west");
            Assert.IsTrue(userInput.Arguments.Count == 1);
        }
    }
}
