namespace BalloonsPop.Data
{
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Models;

    internal class BalloonsData : IBalloonsData
    {
        public BalloonsData(IGenericRepository<Player> players, IGenericRepository<Game> games)
        {
            this.Players = players;
            this.Games = games;
        }

        public IGenericRepository<Game> Games { get; private set; }

        public IGenericRepository<Player> Players { get; private set; }
    }
}