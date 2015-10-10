namespace BalloonsPop.Factories
{
    using System;
    using Common.Constants;
    using Common.Enums;
    using Contexts.Contracts;
    using Contracts;
    using Models;

    internal class GameFactory : IGameFieldFactory
    {
        public Game CreateGame(GameDifficulty input)
        {
            switch (input)
            {
                case GameDifficulty.Easy:
                    return new Game(new GameField(GlobalConstants.EasyLevelRows, GlobalConstants.EasyLevelCols));
                case GameDifficulty.Medium:
                    return new Game(new GameField(GlobalConstants.MediumLevelRows, GlobalConstants.MediumLevelCols));
                case GameDifficulty.Hard:
                    return new Game(new GameField(GlobalConstants.HardLevelRows, GlobalConstants.HardLevelCols));
                case GameDifficulty.Torture:
                    return new Game(new GameField(GlobalConstants.TortureLevelRows, GlobalConstants.TortureLevelCols));
                default:
                    return null;
            }
        }
    }
}
