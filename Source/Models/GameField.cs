//-----------------------------------------------------------------------
// <copyright file="GameField.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the GameField class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Models
{
    using System;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Common.Enums;
    using BalloonsPop.Models.Contracts;

    /// <summary>
    /// Class that creates a game field and provides methods for getting, updating and cloning the game field and
    /// filling it with balloons.
    /// </summary>
    public class GameField : IPrototype<GameField>
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="GameField"/> class.
        /// </summary>
        /// <param name="fieldRows">The rows of the game field.</param>
        /// <param name="fieldCols">The columns of the game field.</param>
        public GameField(int fieldRows, int fieldCols)
        {
            this.FieldRows = fieldRows;
            this.FieldCols = fieldCols;
            this.Field = new char[this.FieldRows, this.FieldCols];

            this.FillWithBalloons();
        }

        /// <summary>
        /// The field of the game.
        /// </summary>
        public char[,] Field { get; set; }

        /// <summary>
        /// Gets the rows of the field.
        /// </summary>
        /// <value>The rows of the field.</value>
        public int FieldRows { get; private set; }

        /// <summary>
        /// Gets the columns of the field.
        /// </summary>
        /// <value>The columns of the field.</value>
        public int FieldCols { get; private set; }

        /// <summary>
        /// Indexer for access to the game field.
        /// </summary>
        /// <param name="row">The rows of the field.</param>
        /// <param name="col">The columns of the field.</param>
        /// <returns>Particular value from the game field instance.</returns>
        public char this[int row, int col]
        {
            get
            {
                if (col < 0 || col > this.FieldCols - 1 || row < 0 || row > this.FieldRows - 1)
                {
                    throw new IndexOutOfRangeException(GlobalMessages.InvalidIndexOfFieldExceptionMsg);
                }
                else
                {
                    return this.Field[row, col];
                }
            }

            set
            {
                if (col < 0 || col > this.FieldCols - 1 || row < 0 || row > this.FieldRows - 1)
                {
                    throw new IndexOutOfRangeException(GlobalMessages.InvalidIndexOfFieldExceptionMsg);
                }
                else
                {
                    this.Field[row, col] = value;
                }
            }
        }

        /// <summary>
        /// Gets the field of the game.
        /// </summary>
        /// <returns>The game field.</returns>
        public char[,] GetField()
        {
            return this.Field;
        }

        /// <summary>
        /// Updates the field of the game.
        /// </summary>
        /// <param name="currentPosition">The current coordinates on the abscissa and ordinate.</param>
        /// <param name="baloonValue">The symbol of the balloon.</param>
        public void UpdateField(ICoordinates currentPosition, char baloonValue)
        {
            this.Field[currentPosition.X, currentPosition.Y] = baloonValue;
        }

        /// <summary>
        /// Fills the game field with balloons.
        /// </summary>
        public void FillWithBalloons()
        {
            Random random = new Random();
            ICoordinates currentPosition = new Coordinates();
            for (int row = 0; row < this.FieldRows; row++)
            {
                for (int column = 0; column < this.FieldCols; column++)
                {
                    currentPosition.X = row;
                    currentPosition.Y = column;

                    var variousOfColors = (char)(random.Next((int)BallonType.First - (int)'0', (int)BallonType.Fifth - (int)'0') + (int)'0');
                    if (this.FieldRows > 20)
                    {
                        variousOfColors = (char)(random.Next((int)BallonType.First - (int)'0', (int)BallonType.Fifth - (int)'0' + 1) + (int)'0');
                    }

                    this.UpdateField(
                        currentPosition,
                        variousOfColors);
                }
            }
        }

        /// <summary>
        /// Clones the game field.
        /// </summary>
        /// <returns>The cloned game field.</returns>
        public GameField Clone()
        {
            var clone = new GameField(this.FieldRows, this.FieldCols);

            for (int i = 0; i < clone.FieldRows; i++)
            {
                for (int j = 0; j < clone.FieldCols; j++)
                {
                    clone[i, j] = this.Field[i, j];
                }
            }

            return clone;
        }
    }
}