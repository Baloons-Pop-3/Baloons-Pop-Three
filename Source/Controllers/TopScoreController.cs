namespace BalloonsPop.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BalloonsPop.Controllers.Contracts;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Models;
    using Models.Contracts;

    public class TopScoreController : ITopScoreController
    {
        public TopScoreController(IGenericRepository<Player> players)
        {
            this.Players = players;
        }

        private IGenericRepository<Player> Players { get; set; }

        public void AddPlayer(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player null");
            }

            this.Players.Add((Player)player);
        }

        public IEnumerable<IPlayer> All()
        {
            return this.Players.All();
        }

        public IEnumerable<IPlayer> GetTop(int count)
        {
            if (count < 0)
            {
                throw new IndexOutOfRangeException("count cannot be negative");
            }

            return this.Players.All().OrderByDescending(p => p.Score).Take(count);
        }
    }
}