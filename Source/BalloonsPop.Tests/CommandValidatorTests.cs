namespace BalloonsPop.Tests
{
    using System;

    using Common.Enums;
    using Common.Validators;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CommandValidator_WhenTypeOfCommandIsInIncorrectFormatShouldThrow()
        {
            var commandValidator = new CommandValidator<char>();
        }

        [TestMethod]
        public void CommandValidator_WhenTypeOfCommandIsInICorrectFormatShouldNotThrow()
        {
            var commandValidator = new CommandValidator<CommandType>();
        }

        [TestMethod]
        public void IsValidCommand_WhenCommandIsInvalidShouldReturnFalse()
        {
            var commandValidator = new CommandValidator<CommandType>();
            var command = "go";

            Assert.IsFalse(commandValidator.IsValidCommand(command));
        }

        [TestMethod]
        public void IsValidCommand_WhenCommandIsValidShouldReturnTrue()
        {
            var commandValidator = new CommandValidator<CommandType>();
            var command = "start";

            Assert.IsTrue(commandValidator.IsValidCommand(command));
        }

        [TestMethod]
        public void GetType_ShouldNotThrowWhenInputIsInCorrectFormat()
        {
            var commandValidator = new CommandValidator<CommandType>();
            var input = "start";
            commandValidator.GetType(input);  
        }
    }
}
