//-----------------------------------------------------------------------
// <copyright file="IContext.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the IContext class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Contexts.Contracts
{
    using Controllers.Contracts;
    using Data.Contracts;
    using LogicProviders.Contracts;
    using Mementos;
    using Printer.Contracts;
    using Reader.Contracts;

    /// <summary>
    /// Defines different kinds of commands, used by the game engine.
    /// </summary>
    public interface IContext
    {
        IGameLogicProvider GameLogic { get; }

        IGamePrinter Printer { get; }

        IReader Reader { get; }

        IBalloonsData DataBase { get; }

        ITopScoreController TopScoreController { get; }

        IGamesController GamesController { get; }

        GameStateMemory Memory { get; set; }
    }
}