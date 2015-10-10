//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the Player class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Models
{
    using System;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Models.Contracts;
    using Common.Constants;

    /// <summary>
    /// A class representing the game user.
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Constant that holds the name of a component. Used for error message in the setter of the property
        /// 'Name' in case of exception.
        /// </summary>
        private const string ComponentName = "Player";

        /// <summary>
        /// Constant that holds the name of the property 'Score'. Used for error message in the setter of the 
        /// property 'Score' in case of exception.
        /// </summary>
        private const string ComponentScore = "Score";

        /// <summary>
        /// The name of the player.
        /// </summary>
        private string name;

        /// <summary>
        /// The scores of the player.
        /// </summary>
        private int score;

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        /// <value>The name of the player.</value>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ComponentName + GlobalMessages.NullExceptionMsg);
                }

                this.name = value;
            }
        }

        /// <summary>
        ///  Gets or sets the scores of the player.
        /// </summary>
        /// <value>The scores of the player.</value>
        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ComponentScore + GlobalMessages.ScoreNegativeMsg);
                }

                this.score = value;
            }
        }

        /// <summary>
        /// Gets or sets user Id.
        /// </summary>
        /// <value>The id of the player.</value>
        public string Id { get; set; }
    }
}