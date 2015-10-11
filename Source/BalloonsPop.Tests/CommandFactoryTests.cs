namespace BalloonsPop.Tests
{
    using BalloonsPop.Commands;
    using BalloonsPop.Commands.Contracts;
    using Common.Enums;
    using Factories;
    using Factories.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandFactoryTests
    {
        private readonly ICommandFactory factory;

        public CommandFactoryTests()
        {
            this.factory = new CommandFactory();
        }

        [TestMethod]
        public void CreateCommand_WithStart_ShouldCreateStartCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Start);

            Assert.IsTrue(command.GetType() == typeof(StartCommand));
        }

        [TestMethod]
        public void CreateCommand_WithExit_ShouldCreateExitCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Exit);

            Assert.IsTrue(command.GetType() == typeof(ExitCommand));
        }

        [TestMethod]
        public void CreateCommand_WithFinish_ShouldCreateFinishCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Finish);

            Assert.IsTrue(command.GetType() == typeof(FinishCommand));
        }

        [TestMethod]
        public void CreateCommand_WithRestart_ShouldCreateRestartCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Restart);

            Assert.IsTrue(command.GetType() == typeof(RestartCommand));
        }

        [TestMethod]
        public void CreateCommand_WithRestore_ShouldCreateRestoreCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Restore);

            Assert.IsTrue(command.GetType() == typeof(RestoreCommand));
        }

        [TestMethod]
        public void CreateCommand_WithTop_ShouldCreateTopScoreCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Top);

            Assert.IsTrue(command.GetType() == typeof(TopScoreCommand));
        }

        [TestMethod]
        public void CreateCommand_WithUndo_ShouldCreateUndoCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Undo);

            Assert.IsTrue(command.GetType() == typeof(UndoCommand));
        }

        [TestMethod]
        public void CreateCommand_WithSave_ShouldCreateSaveCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Save);

            Assert.IsTrue(command.GetType() == typeof(SaveCommand));
        }

        [TestMethod]
        public void CreateCommand_IfCommandAlreadyExists_ShouldReturnFromStorage()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Save);
            ICommand sameCommand = this.factory.CreateCommand(CommandType.Save);

            Assert.IsTrue(sameCommand.GetType() == typeof(SaveCommand));
        }
    }
}
