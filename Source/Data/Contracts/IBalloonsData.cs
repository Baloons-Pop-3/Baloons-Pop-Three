//-----------------------------------------------------------------------
// <copyright file="IBalloonsData.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the IBalloonsData interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Data.Contracts
{
    using BalloonsPop.Models;

    /// <summary>
    /// Interface for more abstract way of getting the players and respective games for saving and loading purposes.
    /// </summary>
    public interface IBalloonsData
    {
        /// <summary>
        /// Gets the players.
        /// </summary>
        IGenericRepository<Player> Players { get; }

        /// <summary>
        /// Gets the games.
        /// </summary>
        IGenericRepository<Game> Games { get; }
    }
}