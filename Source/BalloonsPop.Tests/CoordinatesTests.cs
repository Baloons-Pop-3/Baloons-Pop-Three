namespace BalloonsPop.Tests
{
    using Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class CoordinatesTests
    {
        private readonly Coordinates coordinates;

        public CoordinatesTests()
        {
            this.coordinates = new Coordinates();
        }

        [TestMethod]
        public void TryParse_WhenStringWith2ComasProvided_ShouldReturnFalse()
        {
            var actual=this.coordinates.TryParse("a,a,a");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TryParse_WhenStringWith2SpacesProvided_ShouldReturnFalse()
        {
            var actual = this.coordinates.TryParse("a a a");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TryParse_WhenNullValueProvided_ShouldReturnFalse()
        {
            var actual = this.coordinates.TryParse(null);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TryParse_WhenNotIntegersProvided_ShouldReturnFalse()
        {
            var actual = this.coordinates.TryParse("a a");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TryParse_WhenValidInput_ShouldReturnTrue()
        {
            var actual = this.coordinates.TryParse("-1 24");

            Assert.IsTrue(actual);
        }


    }
}
