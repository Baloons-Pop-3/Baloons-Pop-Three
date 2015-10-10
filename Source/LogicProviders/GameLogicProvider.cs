//-----------------------------------------------------------------------
// <copyright file="GameLogicProvider.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the GameLogicProvider class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.LogicProviders
{
    using System;
    using Common.Constants;
    using Common.Enums;
    using Contracts;
    using Models;
    using Models.Contracts;

    /// <summary>
    /// Class that provides the logic for the game for shooting, swaping, landing and getting the type of the balloons.
    /// </summary>
    internal class GameLogicProvider : IGameLogicProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogicProvider"/> class.
        /// </summary>
        /// <param name="game">The game for which a logic will be provided.</param>
        public GameLogicProvider(Game game)
        {
            this.Game = game;
        }

        /// <summary>
        /// Gets or sets the game.
        /// </summary>
        /// <value>The game to be set.</value>
        public IGame Game { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the game is over.
        /// </summary> 
        /// <value>True - if the game is over or otherwise - false.</value>
        public bool IsGameOver { get; set; }

        /// <summary>
        /// Shoots a balloon at a position passed as a parameter.
        /// </summary>
        /// <param name="positionToShoot">The position of the balloon.</param>
        public void ShootBalloonAtPosition(ICoordinates positionToShoot)
        {
            char balloonToShoot = this.GetBaloonTypeFromPosition(positionToShoot);

            if (balloonToShoot == (char)BallonType.Popped)
            {
                throw new ArgumentException(GlobalMessages.AlreadyPoppedBalloonsMsg);
            }
            else if (balloonToShoot == (char)BallonType.Invalid)
            {
                throw new ArgumentException(GlobalMessages.InvalidCoordinatesExceptionMsg);
            }

            this.Game.Field.UpdateField(positionToShoot, '.');
            this.Game.RemainingBalloons--;

            this.ShootSameBalloonsInDirection(ShootingDirection.Up, positionToShoot, balloonToShoot);
            this.ShootSameBalloonsInDirection(ShootingDirection.Down, positionToShoot, balloonToShoot);
            this.ShootSameBalloonsInDirection(ShootingDirection.Left, positionToShoot, balloonToShoot);
            this.ShootSameBalloonsInDirection(ShootingDirection.Right, positionToShoot, balloonToShoot);

            this.Game.ShootCounter++;
            this.LandFlyingBaloons();
        }

        /// <summary>
        /// Shoots same balloons in a direction.
        /// </summary>
        /// <param name="direction">The direction to shoot - left, right, up or down.</param>
        /// <param name="startingPoint">The starting coordinates.</param>
        /// <param name="balloonToShoot">The type of the balloon.</param>
        private void ShootSameBalloonsInDirection(ShootingDirection direction, ICoordinates startingPoint, char balloonToShoot)
        {
            ICoordinates nextCoordinates = new Coordinates();
            nextCoordinates.X = startingPoint.X;
            nextCoordinates.Y = startingPoint.Y;

            switch (direction)
            {
                case ShootingDirection.Left:
                    {
                        nextCoordinates.X--;
                        break;
                    }

                case ShootingDirection.Right:
                    {
                        nextCoordinates.X++;
                        break;
                    }

                case ShootingDirection.Up:
                    {
                        nextCoordinates.Y--;
                        break;
                    }

                case ShootingDirection.Down:
                    {
                        nextCoordinates.Y++;
                        break;
                    }
            }

            while (balloonToShoot == this.GetBaloonTypeFromPosition(nextCoordinates))
            {
                this.Game.Field.UpdateField(nextCoordinates, '.');
                this.Game.RemainingBalloons--;

                switch (direction)
                {
                    case ShootingDirection.Left:
                        {
                            nextCoordinates.X--;
                            break;
                        }

                    case ShootingDirection.Right:
                        {
                            nextCoordinates.X++;
                            break;
                        }

                    case ShootingDirection.Up:
                        {
                            nextCoordinates.Y--;
                            break;
                        }

                    case ShootingDirection.Down:
                        {
                            nextCoordinates.Y++;
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Gets the type of the balloon from a particular position.
        /// </summary>
        /// <param name="currentPosition">The current coordinates of the balloon.</param>
        /// <returns>The type of the balloon.</returns>
        private char GetBaloonTypeFromPosition(ICoordinates currentPosition)
        {
            bool isOutOfBoard = currentPosition.X < 0
                || currentPosition.Y < 0
                || currentPosition.X > this.Game.Field.FieldRows - 1
                || currentPosition.Y > this.Game.Field.FieldCols - 1;

            if (isOutOfBoard)
            {
                return (char)BallonType.Invalid;
            }

            return this.Game.Field[currentPosition.X, currentPosition.Y];
        }

        /// <summary>
        /// Lands the flying balloons.
        /// </summary>
        private void LandFlyingBaloons()
        {
            for (int column = 0; column < this.Game.Field.FieldCols; column++)
            {
                for (int row = 0; row < this.Game.Field.FieldRows; row++)
                {
                    ICoordinates positionToCheck = new Coordinates(row, column);
                    if (this.GetBaloonTypeFromPosition(positionToCheck) == '.')
                    {
                        for (int k = row; k > 0; k--)
                        {
                            ICoordinates oldCoordinates = new Coordinates(k, column);
                            ICoordinates newCoordinates = new Coordinates(k - 1, column);

                            this.SwapBalloons(oldCoordinates, newCoordinates);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Swaps the balloons.
        /// </summary>
        /// <param name="currentPosition">The current coordinates of the balloon.</param>
        /// <param name="newPosition">The new coordinates of the balloon.</param>
        private void SwapBalloons(ICoordinates currentPosition, ICoordinates newPosition)
        {
            char balloonToSwap = this.GetBaloonTypeFromPosition(currentPosition);
            char balloonToBeSwapped = this.GetBaloonTypeFromPosition(newPosition);

            this.Game.Field.UpdateField(currentPosition, balloonToBeSwapped);
            this.Game.Field.UpdateField(newPosition, balloonToSwap);
        }
    }
}