namespace BalloonsPop.TopScoreBoard
{
    using System.Collections.Generic;
    using BalloonsPop.Data;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Models;

    internal interface ITopScoreController
    {
        IEnumerable<Player> GetTop(int count);

        IEnumerable<Player> All();

        void AddPlayer(Player player);
    }
}