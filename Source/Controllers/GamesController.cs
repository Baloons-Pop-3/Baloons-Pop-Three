namespace BalloonsPop.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data.Contracts;
    using Models;

    public class GamesController : IGamesController
    {
        public GamesController(IGenericRepository<Game> games)
        {
            this.Games = games;
        }

        public IGenericRepository<Game> Games { get; private set; }

        public void AddGame(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException("game null");
            }

            this.Games.Add(game);
        }

        public IEnumerable<Game> All()
        {
            return this.Games.All();
        }

        public Game SearchById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("null or whitespace id of game");
            }

            return this.Games.Find(id);
        }
    }
}
