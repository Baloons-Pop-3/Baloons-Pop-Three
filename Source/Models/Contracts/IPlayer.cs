//-----------------------------------------------------------------------
// <copyright file="IPlayer.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the IPlayer interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Models.Contracts
{
    /// <summary>
    /// Interface that provides properties for getting and setting the score and name of the player.
    /// </summary>
    public interface IPlayer : IModel
    {
        /// <summary>
        /// Gets or sets the score of the player.
        /// </summary>
        /// <value>The score of the player.</value>
        int Score { get; set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        /// <value>The name of the player.</value>
        string Name { get; set; }
    }
}
