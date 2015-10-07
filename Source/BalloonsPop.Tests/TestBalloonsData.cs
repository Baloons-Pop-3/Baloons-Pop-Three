namespace BalloonsPop.Tests.Mocks
{
    using System;
    using System.Linq;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Models;

    internal class TestBalloonsData : IBalloonsData
    {
        public TestBalloonsData(IGenericRepository<Player> players, IGenericRepository<Game> games)
        {
            this.Players = players;
            this.Games = games;
        }

        public IGenericRepository<Game> Games { get; private set; }

        public IGenericRepository<Player> Players { get; private set; }
    }
}
