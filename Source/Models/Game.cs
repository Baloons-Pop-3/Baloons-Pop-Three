//-----------------------------------------------------------------------
// <copyright file="Game.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the Game class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Models
{
    using System;
    using Mementos;
    using Models.Contracts;

    /// <summary>
    /// Class that creates new games' instances and provides methods for saving and restoring the state of the game.
    /// </summary>
    public class Game : IPrototype<IGame>, IModel, IGame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="field">The field that the game will use.</param>
        public Game(GameField field)
        {
            this.Field = field;
            this.RemainingBalloons = field.FieldRows * field.FieldCols;
            this.ShootCounter = 0;
        }

        /// <summary>
        /// Gets or sets the id of the game.
        /// </summary>
        /// <value>The id of the game.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the field of the game.
        /// </summary>
        /// <value>The field of the game.</value>
        public GameField Field { get; set; }

        /// <summary>
        /// Gets or sets the counter of the shoots in the game.
        /// </summary>
        /// <value>The counter of the shoots.</value>
        public int ShootCounter { get; set; }

        /// <summary>
        /// Gets or sets the remaining balloons in the game.
        /// </summary>
        /// <value>The remaining balloons.</value>
        public int RemainingBalloons { get; set; }

        /// <summary>
        /// Saves the current state of the game.
        /// </summary>
        /// <returns>New memento with the saved state of the game.</returns>
        public GameMemento SaveMemento()
        {
            return new GameMemento(this.Field, this.ShootCounter, this.RemainingBalloons);
        }

        /// <summary>
        /// Restores previous state of the game.
        /// </summary>
        /// <param name="memento">The previous state to be restored.</param>
        public void RestoreMemento(GameMemento memento)
        {
            this.Field = memento.Field;
            this.ShootCounter = memento.ShootCounter;
            this.RemainingBalloons = memento.RemainingBalloons;
        }

        /// <summary>
        /// Clones the current game.
        /// </summary>
        /// <returns>Cloned game with the same count of remaining balloons and total shoots.</returns>
        public IGame Clone()
        {
            var game = new Game(this.Field);
            game.RemainingBalloons = this.RemainingBalloons;
            game.ShootCounter = this.ShootCounter;

            return game;
        }
    }
}