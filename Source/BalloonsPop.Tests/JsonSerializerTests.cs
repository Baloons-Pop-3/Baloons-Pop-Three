namespace BalloonsPop.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPop.Models;
    using BalloonsPop.Common.Serializer;

    [TestClass]
    public class JsonSerializerTests
    {
        [TestMethod]
        public void JsonSerializer_ShouldReturnCorrectResultWhenInputHasNoProperies()
        {
            var serializer = new JsonSerializer();
            Player input = new Player {};
            string expResult = "{\"Name\":null,\"Score\":0,\"Id\":null}" ; 

            Assert.AreEqual(expResult, serializer.Serialize<Player>(input));
        }

        [TestMethod]
        public void JsonSerializer_ShouldReturnCorrectResultWhenCorrectInput()
        {
            var serializer = new JsonSerializer();
            Player input = new Player { Name = "Test", Score = 65, Id = "1" };
            string expResult = "{\"Name\":\"Test\",\"Score\":65,\"Id\":\"1\"}";

            Assert.AreEqual(expResult, serializer.Serialize<Player>(input));
        }

        [TestMethod]
        public void JsonDeserializer_ShouldReturnCorrectResultWhenCorrectInput()
        {
            var serializer = new JsonSerializer();
            string input = "{\"Name\":\"Test\",\"Score\":65,\"Id\":\"1\"}";
            Player expResult = new Player { Name = "Test", Score = 65, Id = "1" };

            Assert.AreEqual(expResult.Name, serializer.Deserialize<Player>(input).Name);
            Assert.AreEqual(expResult.Score, serializer.Deserialize<Player>(input).Score);
            Assert.AreEqual(expResult.Id, serializer.Deserialize<Player>(input).Id);
        }
    }
}
