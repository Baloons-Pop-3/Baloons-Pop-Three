//-----------------------------------------------------------------------
// <copyright file="GameEngine.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the GameEngine class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Engine
{
    using System;
    using Commands.Contracts;
    using Common.Constants;
    using Common.Enums;
    using Common.Validators;
    using Contexts;
    using Contexts.Contracts;
    using Contracts;
    using Controllers.Contracts;
    using Data.Contracts;
    using Factories;
    using Factories.Contracts;
    using LogicProviders.Contracts;
    using Models;
    using Models.Contracts;
    using Printer.Contracts;
    using Reader.Contracts;

    /// <summary>
    /// Class that provides an engine for the game and a method for starting the game.
    /// </summary>
    internal class GameEngine : IGameEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class.
        /// </summary>
        /// <param name="gameLogic">The logic of the game.</param>
        /// <param name="printer">The printer of the game.</param>
        /// <param name="reader">The reader of the input of the game.</param>
        /// <param name="db">The database of the game.</param>
        /// <param name="topScoreController">The controller of the top scores.</param>
        /// <param name="gamesController">The controller of the game.</param>
        public GameEngine(IGameLogicProvider gameLogic, IGamePrinter printer, IReader reader, IBalloonsData db, ITopScoreController topScoreController, IGamesController gamesController)
        {
            this.GameLogic = gameLogic;
            this.Printer = printer;
            this.Reader = reader;
            this.DataBase = db;
            this.TopScoreController = topScoreController;
            this.GamesController = gamesController;

            this.Context = new Context(this.DataBase, this.GameLogic, this.Printer, this.Reader, this.TopScoreController, this.GamesController);
            this.Factory = new CommandFactory();
            this.CommandValidator = new CommandValidator<CommandType>();
        }

        /// <summary>
        /// Gets the database of the game.
        /// </summary>
        /// <value>The database of the game.</value>
        public IBalloonsData DataBase { get; private set; }

        /// <summary>
        /// Gets the logic for the game.
        /// </summary>
        /// <value>The logic for the game.</value>
        public IGameLogicProvider GameLogic { get; private set; }

        /// <summary>
        /// Gets the printer of the game.
        /// </summary>
        /// <value>The printer of the game.</value>
        public IGamePrinter Printer { get; private set; }

        /// <summary>
        /// Gets the reader of the game.
        /// </summary>
        /// <value>The reader of the game.</value>
        public IReader Reader { get; private set; }

        /// <summary>
        /// Gets the controller of the top scores.
        /// </summary>
        /// <value>The controller of the top scores.</value>
        public ITopScoreController TopScoreController { get; private set; }

        /// <summary>
        /// Gets the controller of the game.
        /// </summary>
        /// <value>The controller of the game.</value>
        public IGamesController GamesController { get; private set; }

        /// <summary>
        /// Gets the context of the game.
        /// </summary>
        /// <value>The context of the game.</value>
        public IContext Context { get; private set; }

        /// <summary>
        /// Gets the command factory for the game.
        /// </summary>
        /// <value>The command factory for the game.</value>
        public ICommandFactory Factory { get; private set; }
         
        /// <summary>
        /// Gets the validator of the commands.
        /// </summary>
        /// <value>The validator of the commands.</value>
        public CommandValidator<CommandType> CommandValidator { get; private set; }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        {
            this.Printer.PrintMessage(GlobalMessages.GreetingMsg);

            while (this.GameLogic.Game.RemainingBalloons > 0)
            {
                var input = this.Reader.ReadInput();
                this.Printer.CleanDisplay();
                this.Printer.PrintMessage(GlobalMessages.GreetingMsg);
               
                this.ProcessInput(input);

                if (this.GameLogic.IsGameOver)
                {
                    return;
                }
            }

            ICommand command = this.Factory.CreateCommand(CommandType.Finish);
            command.Execute(this.Context);
        }

        /// <summary>
        /// Saves the last state of the game.
        /// </summary>
        private void SaveLastStateOfGame()
        {
            this.Context.Memory.GameMemento = this.GameLogic.Game.SaveMemento();
        }

        /// <summary>
        /// Processes the input.
        /// </summary>
        /// <param name="input">The input string to be processed.</param>
        private void ProcessInput(string input)
        {
            ICoordinates coordinates = new Coordinates();

            if (this.CommandValidator.IsValidCommand(input))
            {
                ICommand command = this.Factory.CreateCommand(this.CommandValidator.GetType(input));
                command.Execute(this.Context);
            }
            else if (coordinates.TryParse(input))
            {
                string msg = GlobalMessages.RowColMsg;

                try
                {
                    this.SaveLastStateOfGame();

                    this.GameLogic.ShootBalloonAtPosition(coordinates);
                }
                catch (ArgumentException ex)
                {
                    msg = ex.Message;
                }

                this.Printer.PrintGameBoard(this.GameLogic.Game.Field);
                this.Printer.PrintMessage(msg);
            }
            else
            {
                this.Printer.PrintGameBoard(this.GameLogic.Game.Field);
                this.Printer.PrintMessage(GlobalMessages.InvalidCommandMsg);
            }
        }
    }
}