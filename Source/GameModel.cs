namespace BalloonsPop
{
    using System;
    using Common;

    internal class GameModel
    {
        public GameModel(GameField field)
        {
            this.RemainingBaloons = field.BalloonsCols*field.BalloonsRows;
            this.ShootCounter = 0;
            this.Field = field;
        }

        public GameField Field { get; set; }

        public int ShootCounter
        {
            private set; get;
        }
        public int RemainingBaloons
        {
            private set; get;
        }

        public void ShootBalloonAtPosition(Coordinates currentPosition)
        {
            char currentBaloon;
            currentBaloon = GetBaloonFromPosition(currentPosition);
            Coordinates tempCoordinates = new Coordinates();

            if (currentBaloon < '1' || currentBaloon > '4')
            {
                // TODO: Find a way to return concrete exception. Code need some refactoring or coupling with Printer
                throw new ArgumentException("Invalid coordinates or already pop balloon");
            }

            this.Field.UpdateField(currentPosition, '.');
            this.RemainingBaloons--;

            // TODO: if possible extract method of the repeated logic

            tempCoordinates.X = currentPosition.X - 1;
            tempCoordinates.Y = currentPosition.Y;
            while (currentBaloon == GetBaloonFromPosition(tempCoordinates))
            {
                this.Field.UpdateField(tempCoordinates, '.');
                this.RemainingBaloons--;
                tempCoordinates.X--;
            }

            tempCoordinates.X = currentPosition.X + 1; tempCoordinates.Y = currentPosition.Y;
            while (currentBaloon == GetBaloonFromPosition(tempCoordinates))
            {
                this.Field.UpdateField(tempCoordinates, '.');
                this.RemainingBaloons--;
                tempCoordinates.X++;
            }

            tempCoordinates.X = currentPosition.X;
            tempCoordinates.Y = currentPosition.Y - 1;
            while (currentBaloon == GetBaloonFromPosition(tempCoordinates))
            {
                this.Field.UpdateField(tempCoordinates, '.');
                this.RemainingBaloons--;
                tempCoordinates.Y--;
            }

            tempCoordinates.X = currentPosition.X;
            tempCoordinates.Y = currentPosition.Y + 1;
            while (currentBaloon == GetBaloonFromPosition(tempCoordinates))
            {
                this.Field.UpdateField(tempCoordinates, '.');
                this.RemainingBaloons--;
                tempCoordinates.Y++;
            }

            this.ShootCounter++;
            LandFlyingBaloons();
        }

        private char GetBaloonFromPosition(Coordinates currentPosition)
        {
            // TODO: extract validator
            bool isOutOfBoard = currentPosition.X < 0
                || currentPosition.Y < 0
                || currentPosition.X > this.Field.BalloonsCols - 1
                || currentPosition.Y > this.Field.BalloonsRows - 1;

            if (isOutOfBoard)
            {
                return 'e';
            }

            int xPosition = 4 + (currentPosition.X * 2);
            int yPosition = 2 + currentPosition.Y;

            return this.Field[xPosition, yPosition];
        }

        private void ChnageBalloonPosition(Coordinates currentPosition, Coordinates newPosition)
        {
            char tmp = GetBaloonFromPosition(currentPosition);
            this.Field.UpdateField(currentPosition, GetBaloonFromPosition(newPosition));
            this.Field.UpdateField(newPosition, tmp);
        }

        private void LandFlyingBaloons()
        {
            Coordinates currentPosition = new Coordinates();
            for (int column = 0; column < GlobalConstants.BALLOONS_BOARD_COLS; column++)
            {
                for (int row = 0; row < GlobalConstants.BALLOONS_BOARD_ROWS; row++)
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