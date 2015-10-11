//-----------------------------------------------------------------------
// <copyright file="IGameBoardDrawingLogic.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the IGameBoardDrawingLogic interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Drawer.Contracts
{
    /// <summary>
    /// Interface for game board drawing logic , gets the board.
    /// </summary>
    public interface IGameBoardDrawingLogic
    {
        string[,] Board { get; }
    }
}