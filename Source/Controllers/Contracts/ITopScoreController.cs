//-----------------------------------------------------------------------
// <copyright file="ITopScoreController.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the ITopScoreController interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Controllers.Contracts
{
    using System.Collections.Generic;
    using BalloonsPop.Data;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Models;
    using Models.Contracts;

    /// <summary>
    /// Interface, which controls top score behaviour.
    /// </summary>
    public interface ITopScoreController
    {
        IEnumerable<IPlayer> GetTop(int count);

        IEnumerable<IPlayer> All();

        void AddPlayer(IPlayer player);
    }
}