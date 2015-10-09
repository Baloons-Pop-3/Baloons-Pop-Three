namespace BalloonsPop.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data.Contracts;
    using Models;
    using Models.Contracts;
    using Printer;

    public class GamesController : IGamesController
    {
        public GamesController(IGenericRepository<Game> games)
        {
            this.Games = games;
        }

        public object Board { get; private set; }
        public IGenericRepository<Game> Games { get; private set; }

        public void AddGame(IGame game)
        {
            if (game == null)
            {
                throw new ArgumentNullException("game null");
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
                throw new ArgumentException("null or whitespace id of game");
            }

            return this.Games.Find(id);
        }
    }
}
