namespace BalloonsPop.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BalloonsPop.Controllers.Contracts;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Models;
    using Common.Constants;
    using Models.Contracts;

    public class TopScoreController : ITopScoreController
    {
        private const string ComponentName = "player";
        private const string CountExceptionMsg = "count cannot be negative";

        public TopScoreController(IGenericRepository<Player> players)
        {
            this.Players = players;
        }

        private IGenericRepository<Player> Players { get; set; }

        public void AddPlayer(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(ComponentName + GlobalMessages.NullExceptionMsg);
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
                throw new IndexOutOfRangeException(CountExceptionMsg);
            }

            return this.Players.All().OrderByDescending(p => p.Score).Take(count);
        }
    }
}