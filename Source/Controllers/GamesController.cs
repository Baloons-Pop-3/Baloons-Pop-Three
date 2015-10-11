//-----------------------------------------------------------------------
// <copyright file="GamesController.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the GamesController class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Controllers
{
    using System;
    using System.Collections.Generic;
    using Common.Constants;
    using Contracts;
    using Data.Contracts;
    using Models;
    using Models.Contracts;

    /// <summary>
    /// The class dictates desired game behaviour.
    /// </summary>
    public class GamesController : IGamesController
    {
        private const string ComponentName = "game";

        /// <summary>
        /// Instiates GamesController from given games.
        /// </summary>
        /// <param name="games">Generic.</param>
        public GamesController(IGenericRepository<Game> games)
        {
            this.Games = games;
        }

        /// <summary>
        /// Gets and sets game board.
        /// </summary>
        public object Board { get; private set; }

        /// <summary>
        /// Gets gets games from generic.
        /// </summary>
        public IGenericRepository<Game> Games { get; private set; }

        /// <summary>
        /// Adds new game.
        /// </summary>
        /// <param name="game">Game to add.</param>
        public void AddGame(IGame game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(ComponentName + GlobalMessages.NullExceptionMsg);
            }

            this.Games.Add((Game)game);
        }

        public IEnumerable<IGame> All()
        {
            return this.Games.All();
        }

        public IGame SearchById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException(ComponentName + GlobalMessages.NullIdExceptionMsg);
            }

            return this.Games.Find(id);
        }
    }
}
