using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BalloonsPop.Data;

namespace BalloonsPop.TopScoreBoard
{
    class TopScore2 : ITopScore
    {
        TopScore2(IGenericRepository<Player> highScoreProvider)
        {
            this.HighScores = highScoreProvider;
        }

        public IGenericRepository<Player> HighScores{ get; set; }

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
