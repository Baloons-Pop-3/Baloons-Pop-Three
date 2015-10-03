namespace BalloonsPop
{
    using System;
    using Common.Constants;
    using Common.Enums;
    using Models;
    using LogicProviders.Contracts;
    using Models.Contracts;

    internal class GameLogicProvider:IGameLogicProvider
    {
        public GameLogicProvider(Game game)
        {
            this.Game = game;
        }

        public Game Game { get; set; }

        public void ShootBalloonAtPosition(Coordinates positionToShoot)
        {
            char balloonToShoot = this.GetBaloonTypeFromPosition(positionToShoot);

            if (balloonToShoot == (char)BallonType.Popped)
            {
                throw new ArgumentException(GlobalMessages.AlreadyPoppedBalloonsMsg);
            }
            else if (balloonToShoot == (char)BallonType.Invalid)
            {
                throw new ArgumentException(GlobalMessages.InvalidCoordinatesMsg);
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

        private void ShootSameBalloonsInDirection(ShootingDirection direction, Coordinates startingPoint, char balloonToShoot)
        {
            Coordinates nextCoordinates = new Coordinates();
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

        private char GetBaloonTypeFromPosition(Coordinates currentPosition)
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

        private void LandFlyingBaloons()
        {
            for (int column = 0; column < this.Game.Field.FieldCols; column++)
            {
                for (int row = 0; row < this.Game.Field.FieldRows; row++)
                {
                    Coordinates positionToCheck = new Coordinates(row, column);
                    if (this.GetBaloonTypeFromPosition(positionToCheck) == '.')
                    {
                        for (int k = row; k > 0; k--)
                        {
                            Coordinates oldCoordinates = new Coordinates(k, column);
                            Coordinates newCoordinates = new Coordinates(k - 1, column);

                            this.SwapBalloons(oldCoordinates, newCoordinates);
                        }
                    }
                }
            }
        }

        private void SwapBalloons(Coordinates currentPosition, Coordinates newPosition)
        {
            char balloonToSwap = this.GetBaloonTypeFromPosition(currentPosition);
            char balloonToBeSwapped = this.GetBaloonTypeFromPosition(newPosition);

            this.Game.Field.UpdateField(currentPosition, balloonToBeSwapped);
            this.Game.Field.UpdateField(newPosition, balloonToSwap);
        }
    }
}