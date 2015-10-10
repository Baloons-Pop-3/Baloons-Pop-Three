//-----------------------------------------------------------------------
// <copyright file="IGameLogicProvider.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the IGameLogicProvider interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.LogicProviders.Contracts
{
    using System;
    using System.Linq;
    using Models.Contracts;

    /// <summary>
    /// Interface that provides the logic for the game and a method for shooting the balloons at a position.
    /// </summary>
    public interface IGameLogicProvider
    {
        /// <summary>
        /// Gets or sets the game.
        /// </summary>
        /// <value>The game to be set.</value>
        IGame Game { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the game is over.
        /// </summary> 
        /// <value>True - if the game is over or otherwise - false.</value>
        bool IsGameOver { get; set; }

        /// <summary>
        /// Shoots a balloon at a position passed as a parameter.
        /// </summary>
        /// <param name="positionToShoot">The coordinates of the balloon.</param>
        void ShootBalloonAtPosition(ICoordinates positionToShoot);
    }
}
