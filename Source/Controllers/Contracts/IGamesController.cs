namespace BalloonsPop.Controllers.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BalloonsPop.Models;

    public interface IGamesController
    {
        void AddGame(Game game);

        IEnumerable<Game> All();

        Game SearchById(string id);
    }
}
