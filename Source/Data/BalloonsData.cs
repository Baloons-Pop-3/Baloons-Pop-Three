namespace BalloonsPop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class BalloonsData : IBalloonsData
    {
        public BalloonsData(IGenericRepository<Player> players, IGenericRepository<Game> games)
        {
            this.Players = players;
            this.Games = games;
        }

        public IGenericRepository<Game> Games { private set; get; }

        public IGenericRepository<Player> Players { private set;  get; }
    }
}
