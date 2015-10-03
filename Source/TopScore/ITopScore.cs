namespace BalloonsPop.TopScoreBoard
{
    using System.Collections.Generic;
    using BalloonsPop.Data;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Models;

    internal interface ITopScore
    {
        IGenericRepository<Player> HighScores { get; }

        IEnumerable<Player> GetTop(int count);

        void AddPlayer(Player player);
    }
}