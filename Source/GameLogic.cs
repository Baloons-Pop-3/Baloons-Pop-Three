using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop
{
    class GameLogic
    {
        public GameLogic(Game game)
        {
            this.Game = game;
        }

        public Game Game { get; set; }

        public void ShootBalloonAtPosition(Coordinates positionToShoot)
        {
            char balloonToShoot;
            balloonToShoot = GetBaloonTypeFromPosition(positionToShoot);

            if (balloonToShoot < '1' || balloonToShoot > '4')
            {
                // TODO: Find a way to return concrete exception. Code need some refactoring or coupling with Printer
                throw new ArgumentException("Invalid coordinates or already pop balloon");
            }

            this.Game.Field.UpdateField(positionToShoot, '.');
            this.Game.RemainingBaloons--;

            ShootSameBalloonInDirection(ShootingDirection.Up, positionToShoot, balloonToShoot);
            ShootSameBalloonInDirection(ShootingDirection.Down, positionToShoot, balloonToShoot);
            ShootSameBalloonInDirection(ShootingDirection.Left, positionToShoot, balloonToShoot);
            ShootSameBalloonInDirection(ShootingDirection.Right, positionToShoot, balloonToShoot);

            this.Game.ShootCounter++;
            LandFlyingBaloons();
        }

        private void ShootSameBalloonInDirection(ShootingDirection direction, Coordinates startingPoint,char balloonToShoot)
        {
            Coordinates nextCoordinates = new Coordinates();
            nextCoordinates.X = startingPoint.X;
            nextCoordinates.Y = startingPoint.Y;

            switch (direction)
            {
                case ShootingDirection.Left: nextCoordinates.X--; break;
                case ShootingDirection.Right: nextCoordinates.X++; break;
                case ShootingDirection.Up: nextCoordinates.Y--; break;
                case ShootingDirection.Down: nextCoordinates.Y++; break;
            }

            while (balloonToShoot == GetBaloonTypeFromPosition(nextCoordinates))
            {
                this.Game.Field.UpdateField(nextCoordinates, '.');
                this.Game.RemainingBaloons--;

                switch (direction)
                {
                    case ShootingDirection.Left: nextCoordinates.X--; break;
                    case ShootingDirection.Right: nextCoordinates.X++; break;
                    case ShootingDirection.Up: nextCoordinates.Y--; break;
                    case ShootingDirection.Down: nextCoordinates.Y++; break;
                }
            }
        }

        private char GetBaloonTypeFromPosition(Coordinates currentPosition)
        {
            // TODO: extract validator
            bool isOutOfBoard = currentPosition.X < 0
                || currentPosition.Y < 0
                || currentPosition.X > this.Game.Field.BalloonsCols - 1
                || currentPosition.Y > this.Game.Field.BalloonsRows - 1;

            if (isOutOfBoard)
            {
                return 'e';
            }

            int xPosition = 4 + (currentPosition.X * 2);
            int yPosition = 2 + currentPosition.Y;

            return this.Game.Field[xPosition, yPosition];
        }

        private void SwapBalloons(Coordinates currentPosition, Coordinates newPosition)
        {
            char balloonToSwap = GetBaloonTypeFromPosition(currentPosition);
            char balloonToBeSwapped = GetBaloonTypeFromPosition(newPosition);

            this.Game.Field.UpdateField(currentPosition, balloonToBeSwapped);
            this.Game.Field.UpdateField(newPosition, balloonToSwap);
        }

        private void LandFlyingBaloons()
        {
            for (int column = 0; column < this.Game.Field.BalloonsCols; column++)
            {
                for (int row = 0; row < this.Game.Field.BalloonsRows; row++)
                {
                    Coordinates positionToCheck = new Coordinates(column,row);

                    if (GetBaloonTypeFromPosition(positionToCheck) == '.')
                    {
                        for (int k = row; k > 0; k--)
                        {
                            Coordinates oldCoordinates = new Coordinates(column,k);
                            Coordinates newCoordinates = new Coordinates(column, k - 1);

                            SwapBalloons(oldCoordinates, newCoordinates);
                        }
                    }
                }
            }
        }

    }
}
