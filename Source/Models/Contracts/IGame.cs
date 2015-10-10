//-----------------------------------------------------------------------
// <copyright file="IGame.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the IGame interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Models.Contracts
{
    using BalloonsPop.Mementos;

    /// <summary>
    /// Interface that provides properties for getting and setting the field of the game, the counter of the shoots and
    /// the remaining balloons in the game and methods for saving and restoring the state of the game.
    /// </summary>
    public interface IGame : IModel, IPrototype<IGame>
    {
        /// <summary>
        /// Gets or sets the field of the game.
        /// </summary>
        /// <value>The game field.</value>
        GameField Field { get; set; }

        /// <summary>
        /// Gets or sets the counter of the shoots.
        /// </summary>
        /// <value>The counter of total shoots.</value>
        int ShootCounter { get; set; }

        /// <summary>
        /// Gets or sets the remaining balloons.
        /// </summary> 
        /// <value>The remaining balloons in the game.</value>
        int RemainingBalloons { get; set; }

        /// <summary>
        /// Saves the current state of the game.
        /// </summary>
        /// <returns>New memento with the saved state.</returns>
        GameMemento SaveMemento();

        /// <summary>
        /// Restores previous state of the game.
        /// </summary>
        /// <param name="memento">The state of the game to be restored.</param>
        void RestoreMemento(GameMemento memento);
    }
}
