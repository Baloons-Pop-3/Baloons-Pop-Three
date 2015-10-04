namespace BalloonsPop.TopScoreBoard
{
    using System.Collections.Generic;
    using System.Linq;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Models;
    using System;

    public class TopScore : ITopScore
    {
        public TopScore(IBalloonsData db)
        {
            this.HighScores = db.Players;
        }

        public IGenericRepository<Player> HighScores { get; set; }

        public void AddPlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player null");
            }

            this.HighScores.Add(player);
        }

        public IEnumerable<Player> GetTop(int count)
        {
            if (count < 0)
            {
                throw new IndexOutOfRangeException("count cannot be negative");
            }

            return this.HighScores.All().OrderByDescending(p => p.Score).Take(count);
        }

        public Player Find(string id)
        {
            return this.HighScores.Find(id);
        }
    }
}