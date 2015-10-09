namespace BalloonsPop.Controllers.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BalloonsPop.Models;
    using Models.Contracts;

    public interface IGamesController
    {
        void AddGame(IGame game);

        IEnumerable<IGame> All();

        IGame SearchById(string id);
    }
}
