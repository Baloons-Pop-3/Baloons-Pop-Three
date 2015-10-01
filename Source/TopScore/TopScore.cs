namespace BalloonsPop.TopScoreBoard
{
    using System.Collections.Generic;
    using System.Linq;
    using BalloonsPop.Data;

    internal class TopScore : ITopScore
    {
        public TopScore(IBalloonsData db)
        {
            this.HighScores = db.Players;
        }

        public IGenericRepository<Player> HighScores { get; set; }

        public void AddPlayer(Player player)
        {
            this.HighScores.Add(player);
        }

        public IEnumerable<Player> GetTop(int count)
        {
            return this.HighScores.All().OrderByDescending(p => p.Score).Take(count);
        }
    }
}