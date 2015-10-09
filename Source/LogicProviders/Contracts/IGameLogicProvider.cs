namespace BalloonsPop.LogicProviders.Contracts
{
    using System;
    using System.Linq;
    using BalloonsPop.Models;
    using Models.Contracts;

    public interface IGameLogicProvider
    {
        IGame Game { get; set; }

        void ShootBalloonAtPosition(ICoordinates positionToShoot);
    }
}
