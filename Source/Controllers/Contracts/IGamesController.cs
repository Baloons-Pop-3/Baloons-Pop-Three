//-----------------------------------------------------------------------
// <copyright file="IGamesController.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the IGamesController interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Controllers.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BalloonsPop.Models;
    using Models.Contracts;

    /// <summary>
    /// Interface responsible for game behaviour.
    /// </summary>
    public interface IGamesController
    {
        void AddGame(IGame game);

        IEnumerable<IGame> All();

        IGame SearchById(string id);
    }
}
