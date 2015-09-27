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
            balloonToShoot = GetBaloonFromPosition(positionToShoot);

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
            Coordinates tempCoordinates = new Coordinates();
            tempCoordinates.X = startingPoint.X;
            tempCoordinates.Y = startingPoint.Y;

            switch (direction)
            {
                case ShootingDirection.Left: tempCoordinates.X--; break;
                case ShootingDirection.Right: tempCoordinates.X++; break;
                case ShootingDirection.Up: tempCoordinates.Y--; break;
                case ShootingDirection.Down: tempCoordinates.Y++; break;
            }

            while (balloonToShoot == GetBaloonFromPosition(tempCoordinates))
            {
                this.Game.Field.UpdateField(tempCoordinates, '.');
                this.Game.RemainingBaloons--;

                switch (direction)
                {
                    case ShootingDirection.Left: tempCoordinates.X--; break;
                    case ShootingDirection.Right: tempCoordinates.X++; break;
                    case ShootingDirection.Up: tempCoordinates.Y--; break;
                    case ShootingDirection.Down: tempCoordinates.Y++; break;
                }
            }
        }

        private char GetBaloonFromPosition(Coordinates currentPosition)
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

        private void ChnageBalloonPosition(Coordinates currentPosition, Coordinates newPosition)
        {
            char tmp = GetBaloonFromPosition(currentPosition);
            this.Game.Field.UpdateField(currentPosition, GetBaloonFromPosition(newPosition));
            this.Game.Field.UpdateField(newPosition, tmp);
        }

        private void LandFlyingBaloons()
        {
            Coordinates currentPosition = new Coordinates();
            for (int column = 0; column < this.Game.Field.BalloonsCols; column++)
            {
                for (int row = 0; row < this.Game.Field.BalloonsRows; row++)
                {
                    currentPosition.X = column;
                    currentPosition.Y = row;
                    if (GetBaloonFromPosition(currentPosition) == '.')
                    {
                        for (int k = row; k > 0; k--)
                        {
                            Coordinates tempCoordinates = new Coordinates();
                            Coordinates tempCoordinates1 = new Coordinates();
                            tempCoordinates.X = column;
                            tempCoordinates.Y = k;
                            tempCoordinates1.X = column;
                            tempCoordinates1.Y = k - 1;
                            ChnageBalloonPosition(tempCoordinates, tempCoordinates1);
                        }
                    }
                }
            }
        }

    }
}
