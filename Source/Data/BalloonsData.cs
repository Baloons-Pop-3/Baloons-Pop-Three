//-----------------------------------------------------------------------
// <copyright file="BalloonsData.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the BalloonsData class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Data
{
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Models;

    /// <summary>
    /// Contains the list of players and their games.
    /// </summary>
    internal class BalloonsData : IBalloonsData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BalloonsData" />
        /// Passes important game data.
        /// </summary>
        /// <param name="players">Generic of players.</param>
        /// <param name="games">Generic of games.</param>
        public BalloonsData(IGenericRepository<Player> players, IGenericRepository<Game> games)
        {
            this.Players = players;
            this.Games = games;
        }

        /// <summary>
        /// Gets the generic games and sets it without allowing modifications.
        /// </summary>
        public IGenericRepository<Game> Games { get; private set; }

        /// <summary>
        /// Gets the generic players and sets it without allowing modifications.
        /// </summary>
        public IGenericRepository<Player> Players { get; private set; }
    }
}