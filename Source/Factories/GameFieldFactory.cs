namespace BalloonsPop.Factories
{
    using Contexts.Contracts;
    using Common.Enums;
    using Models;
    using System.Collections.Generic;
    using Common.Constants;
    using Contracts;
    using System;

    class GameFieldFactory:IGameFieldFactory
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
