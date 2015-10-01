namespace BalloonsPop
{
    using System;
    using Common;
    using Models.Contracts;

    /// <summary>
    /// A class representing the game user.
    /// </summary>
    public class Player : IComparable<Player>, IModel
    {
        /// <summary>
        /// The name of the user.
        /// </summary>
        private string name;
        
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
                Validator.ValidateString(value, "Name");
                this.name = value;
            }
        }

        /// <summary>
        ///  Gets the user score and sets it to the value , used for better data understanding.
        /// </summary>
        public int Score { get; set; }

        public string Id { get; set; }

        public static bool operator <(Player x, Player y)
        {
            return x.Score < y.Score;
        }

        public static bool operator >(Player x, Player y)
        {
            return x.Score > y.Score;
        }

        /// <summary>
        /// A method that compares the scores of two players.
        /// </summary>
        /// <param name="otherPlayer">The other player with whose scores player's scores will be compared.</param>
        /// <returns>Less than zero if the current player instance scores are higher than the other player, zero - if they are equal and greater than zero - otherwise.</returns>
        public int CompareTo(Player otherPlayer)
        {
            return this.Score.CompareTo(otherPlayer.Score);
        }
    }
}