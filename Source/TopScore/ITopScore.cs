namespace BalloonsPop.TopScoreBoard
{
    using BalloonsPop.Data;
    using System.Collections.Generic;

    // TODO: Implement ITopScore
    internal interface ITopScore
    {
        IGenericRepository<Player> HighScores { get; }

        IEnumerable<Player> GetTop(int count);

        void AddPlayer(Player player);
    }
}