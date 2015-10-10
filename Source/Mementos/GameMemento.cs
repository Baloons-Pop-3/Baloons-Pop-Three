//-----------------------------------------------------------------------
// <copyright file="GameMemento.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the GameMemento class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Mementos
{
    using BalloonsPop.Models;

    /// <summary>
    /// Class that creates game memento with a saved state of the game.
    /// </summary>
    public class GameMemento
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameMemento"/> class.
        /// </summary>
        /// <param name="field">The field of the game memento.</param>
        /// <param name="shootCounter">The shoot counter of the game memento.</param>
        /// <param name="remainingBallons">The remaining balloons of the game memento.</param>
        public GameMemento(GameField field, int shootCounter, int remainingBallons)
        {
            this.Field = field.Clone();
            this.ShootCounter = shootCounter;
            this.RemainingBalloons = remainingBallons;
        }

        /// <summary>
        /// Gets or sets the field of the game memento.
        /// </summary>
        /// <value>The field of the game memento.</value>
        public GameField Field { get; set; }

        /// <summary>
        /// Gets or sets the shoot counter of the game memento.
        /// </summary>
        /// <value>The counter of the total shoots.</value>
        public int ShootCounter { get; set; }

        /// <summary>
        /// Gets or sets the remaining balloons of the game memento.
        /// </summary>
        /// <value>The remaining balloons.</value>
        public int RemainingBalloons { get; set; }
    }
}