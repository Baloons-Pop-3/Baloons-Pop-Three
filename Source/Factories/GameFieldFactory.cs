namespace BalloonsPop.Factories
{
    using System;
    using Common.Constants;
    using Common.Enums;
    using Contexts.Contracts;
    using Contracts;
    using Models;

    internal class GameFieldFactory : IGameFieldFactory
    {
        public GameFieldFactory(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public GameField CreateGame(GameDifficulty input)
        {
            switch (input)
            {
                case GameDifficulty.Easy:
                    return new GameField(GlobalConstants.EasyLevelRows, GlobalConstants.EasyLevelCols);
                case GameDifficulty.Medium:
                    return new GameField(GlobalConstants.MediumLevelRows, GlobalConstants.MediumLevelCols);
                case GameDifficulty.Hard:
                    return new GameField(GlobalConstants.HardLevelRows, GlobalConstants.HardLevelCols);
                case GameDifficulty.Torture:
                    return new GameField(GlobalConstants.TortureLevelRows, GlobalConstants.TortureLevelRows);
                default:
                    return null;
            }
        }
    }
}
