namespace BalloonsPop.Commands
{
    using Contexts.Contracts;
    using Contracts;
    using Models;

    internal class RestartCommand : ICommand
    {
        public void Execute(IContext context)
        {
            var gameField = new GameField(context.GameLogic.Game.Field.FieldRows, context.GameLogic.Game.Field.FieldCols);
            context.GameLogic.Game = new Game(gameField);
            context.Printer.PrintGameBoard(context.GameLogic.Game.Field);
        }
    }
}