using BowlingGame;
using BowlingGame.Entities;
using BowlingGame.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTests
{
    [TestClass]
    public class ScoreCustomTenPinGameServiceTests
    {
        private Game game;
        private ScoreTenPinGameService scoreTenPinGameService;

        [TestInitialize]
        public void Initialize()
        {
            game = new Custom10PinGame(21);
            scoreTenPinGameService = new ScoreTenPinGameService();
        }

        [TestMethod]
        public void TestAllGutterballs()
        {
            RollMany(20, 0);

            Assert.AreEqual(0, scoreTenPinGameService.ScoreGame(game));
        }

        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(20, 1);

            Assert.AreEqual(20, scoreTenPinGameService.ScoreGame(game));
        }

        [TestMethod]
        public void TestOneSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollMany(17,0);
            
            Assert.AreEqual(16,scoreTenPinGameService.ScoreGame(game));
        }

        [TestMethod]
        public void TestOneSpareAndNumbers()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            game.Roll(3);
            RollMany(16, 0);

            Assert.AreEqual(19, scoreTenPinGameService.ScoreGame(game));
        }

        [TestMethod]
        public void TestZeroFollowedBySpareThenNumber()
        {
            game.Roll(0);
            game.Roll(10);
            game.Roll(5);

            RollMany(17, 0);

            Assert.AreEqual(20, scoreTenPinGameService.ScoreGame(game));
        }

        [TestMethod]
        public void TestStrikeZeroNumber()
        {
            game.Roll(10);
            game.Roll(0);
            game.Roll(3);

            RollMany(17, 0);

            Assert.AreEqual(16, scoreTenPinGameService.ScoreGame(game));
        }

        [TestMethod]
        public void TestOneStrikeThereafterGutterballs()
        {
            game.Roll(10);
           
            RollMany(18, 0);

            Assert.AreEqual(10, scoreTenPinGameService.ScoreGame(game));
        }

        [TestMethod]
        public void TestOneStrikeFollowedByOneNumber()
        {
            game.Roll(10);
            game.Roll(5);

            RollMany(17, 0);

            Assert.AreEqual(20, scoreTenPinGameService.ScoreGame(game));
        }

        [TestMethod]
        public void TestOneStrikeFollowedByTwoNumberNoSpare()
        {
            game.Roll(10);
            game.Roll(5);
            game.Roll(3);

            RollMany(16, 0);

            Assert.AreEqual(26, scoreTenPinGameService.ScoreGame(game));
        }

        [TestMethod]
        public void TestOneStrikeFollowedByStrikeAndNumber()
        {
            game.Roll(10);
            game.Roll(10);
            game.Roll(5);

            RollMany(16, 0);

            Assert.AreEqual(45, scoreTenPinGameService.ScoreGame(game));
        }

        [TestMethod]
        public void TestOneStrikeFollowedByStrikeByTwoNumbers()
        {
            game.Roll(10);
            game.Roll(10);
            game.Roll(5);
            game.Roll(3);

            RollMany(15, 0);

            Assert.AreEqual(51, scoreTenPinGameService.ScoreGame(game));
        }

        [TestMethod]
        public void TestAllStrikes()
        {
            RollMany(12, 10);

            Assert.AreEqual(300, scoreTenPinGameService.ScoreGame(game));
        }

        [TestMethod]
        public void TestAllStrikesSpareOnLastFrame()
        {
            RollMany(10, 10);
            game.Roll(4);
            game.Roll(6);

            Assert.AreEqual(284, scoreTenPinGameService.ScoreGame(game));
        }


        private void RollMany(int numberOfRolls, int pins)
        {
            for (int i = 0; i < numberOfRolls; i++)
                game.Roll(pins);
        }
    }
}
