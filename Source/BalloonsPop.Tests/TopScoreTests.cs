namespace BalloonsPop.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPop;

    [TestClass]
    public class TopScoreTests
    {
        [TestMethod]
        public void IsTopScoreToReturnTrueWhenTopScoreListIsEmpty()
        {
            var topScore = new TopScore();
            var player = new Player();
            Assert.IsTrue(topScore.IsTopScore(player));            
        }
    }
}
