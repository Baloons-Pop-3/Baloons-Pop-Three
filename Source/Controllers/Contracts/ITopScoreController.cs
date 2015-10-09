namespace BalloonsPop.Controllers.Contracts
{
    using System.Collections.Generic;
    using BalloonsPop.Data;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Models;
    using Models.Contracts;

    public interface ITopScoreController
    {
        IEnumerable<IPlayer> GetTop(int count);

        IEnumerable<IPlayer> All();

        void AddPlayer(IPlayer player);
    }
}