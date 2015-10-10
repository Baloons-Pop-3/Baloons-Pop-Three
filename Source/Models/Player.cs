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
        private const string ComponentName = "Player";
        private const string ComponentScore = "Score";

        /// <summary>
        /// The name of the user.
        /// </summary>
        private string name;

        private int score;

        /// <summary>
        /// Gets the user name, and sets it to the correct value via validation.
        /// </summary>
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
        ///  Gets the user score and sets it to the value , used for better data understanding.
        /// </summary>
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
        /// gets or sets user Id 
        /// </summary>
        public string Id { get; set; }
    }
}