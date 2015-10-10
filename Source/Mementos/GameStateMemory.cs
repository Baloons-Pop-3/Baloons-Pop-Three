//-----------------------------------------------------------------------
// <copyright file="GameStateMemory.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the GameStateMemory class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Mementos
{
    /// <summary>
    /// Class that provides a property for getting and setting a memento with a state of the game.
    /// </summary>
    public class GameStateMemory
    {
        /// <summary>
        /// Gets or sets a game memento with a state of the game.
        /// </summary>
        /// <value>The game memento.</value>
        public GameMemento GameMemento { get; set; }
    }
}