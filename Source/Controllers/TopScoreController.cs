namespace BalloonsPop.TopScoreBoard
{
    using System.Collections.Generic;
    using System.Linq;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Models;
    using System;

    public class TopScoreController : ITopScoreController
    {
        public TopScoreController(IGenericRepository<Player> players)
        {
            this.Players = players;
        }

        private IGenericRepository<Player> Players { get; set; }

        public void AddPlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player null");
            }

            this.Players.Add(player);
        }

        public IEnumerable<Player> All()
        {
            return this.Players.All();
        }

        public IEnumerable<Player> GetTop(int count)
        {
            if (count < 0)
            {
                throw new IndexOutOfRangeException("count cannot be negative");
            }

            return this.Players.All().OrderByDescending(p => p.Score).Take(count);
        }
    }
}