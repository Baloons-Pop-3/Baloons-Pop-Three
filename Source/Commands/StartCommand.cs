namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Common.Enums;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Models;

    internal class StartCommand : ICommand
    {
        public StartCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { get; private set; }

        public void Execute()
        {
            this.Context.Printer.PrintMessage(GlobalMessages.StartCommandMessage);
            var input = this.Context.Reader.ReadInput();
            GameField gamefield;

            var validator = new CommandValidator<GameDifficulty>();

            if (validator.IsValidCommand(input))
            {
                if (validator.GetType(input) == GameDifficulty.Easy)
                {
                    gamefield = new GameField(GlobalConstants.EasyLevelRows, GlobalConstants.EasyLevelCols);
                    this.Context.GameLogic.Game = new Game(gamefield);
                }
                else if (validator.GetType(input) == GameDifficulty.Medium)
                {
                    gamefield = new GameField(GlobalConstants.MediumLevelRows, GlobalConstants.MediumLevelCols);
                    this.Context.GameLogic.Game = new Game(gamefield);
                }
                else if (validator.GetType(input) == GameDifficulty.Hard)
                {
                    gamefield = new GameField(GlobalConstants.HardLevelRows, GlobalConstants.HardLevelCols);
                    this.Context.GameLogic.Game = new Game(gamefield);
                }
                else if (validator.GetType(input) == GameDifficulty.Torture)
                {
                    gamefield = new GameField(GlobalConstants.TortureLevelRows, GlobalConstants.TortureLevelRows);
                    this.Context.GameLogic.Game = new Game(gamefield);
                }
            }
            else
            {
                this.Context.Printer.PrintMessage(GlobalMessages.StartCommandInvalidDifficultyMessage);
            }

            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}