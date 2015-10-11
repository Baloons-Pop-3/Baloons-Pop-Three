//-----------------------------------------------------------------------
// <copyright file="GlobalConstants.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the GlobalConstants class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Common.Constants
{
    /// <summary>
    /// Stores all constants and paths.
    /// </summary>
    public class GlobalConstants
    {
        internal const int EasyLevelRows = 5;
        internal const int EasyLevelCols = 5;
        internal const int MediumLevelRows = 8;
        internal const int MediumLevelCols = 8;
        internal const int HardLevelRows = 12;
        internal const int HardLevelCols = 12;
        internal const int TortureLevelRows = 25;
        internal const int TortureLevelCols = 20;
        internal const int DefaultLevelRows = 10;
        internal const int DefaultLevelCols = 10;

        internal const int NumberOfTopPlayers = 5;

        internal const char BalloonsSymbol = '0';

        internal const string TopScorePath = "..\\..\\Content\\TopScore.txt";
        internal const string GamesPath = "..\\..\\Content\\Games.txt";
    }
}