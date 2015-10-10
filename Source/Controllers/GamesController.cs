namespace BalloonsPop.Controllers
{
    using System;
    using System.Collections.Generic;
    using Common.Constants;
    using Contracts;
    using Data.Contracts;
    using Models;
    using Models.Contracts;

    public class GamesController : IGamesController
    {
        private const string ComponentName = "game";

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
