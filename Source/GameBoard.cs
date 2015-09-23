namespace BalloonsPop
{
    using System;
    using Common;

    internal class GameBoard
    {
        private char[,] field = new char[GlobalConstants.GAME_BOARD_ROWS, GlobalConstants.GAME_BOARD_COLS];

        public GameBoard()
        {
            this.RemainingBaloons = GlobalConstants.BALLOONS_BOARD_ROWS * GlobalConstants.BALLOONS_BOARD_COLS;
            this.ShootCounter = 0;
        }

        public char[,] Field
        {
            get
            {
                return this.field;
            }
        }

        public int ShootCounter
        {
            private set; get;
        }
        public int RemainingBaloons
        {
            private set; get;
        }

        public void GenerateBalloons()
        {
            Random random = new Random();
            Coordinates currentPosition = new Coordinates();
            for (int column = 0; column < 10; column++)
            {
                for (int row = 0; row < 5; row++)
                {
                    currentPosition.X = column;
                    currentPosition.Y = row;

                    AddNewBaloonToGameBoard(currentPosition, (char)(random.Next(1, 5) + (int)'0'));
                }
            }
        }

        public void Shoot(Coordinates currentPosition)
        {
            char currentBaloon;
            currentBaloon = GetBaloon(currentPosition);
            Coordinates tempCoordinates = new Coordinates();

            if (currentBaloon < '1' || currentBaloon > '4')
            {
                // TODO: Find a way to return concrete exception. Code need some refactoring or coupling with Printer
                throw new ArgumentException("Invalid coordinates or already pop balloon");
            }

            AddNewBaloonToGameBoard(currentPosition, '.');
            this.RemainingBaloons--;

            // TODO: if possible extract method of the repeated logic

            tempCoordinates.X = currentPosition.X - 1;
            tempCoordinates.Y = currentPosition.Y;
            while (currentBaloon == GetBaloon(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                this.RemainingBaloons--;
                tempCoordinates.X--;
            }

            tempCoordinates.X = currentPosition.X + 1; tempCoordinates.Y = currentPosition.Y;
            while (currentBaloon == GetBaloon(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                this.RemainingBaloons--;
                tempCoordinates.X++;
            }

            tempCoordinates.X = currentPosition.X;
            tempCoordinates.Y = currentPosition.Y - 1;
            while (currentBaloon == GetBaloon(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                this.RemainingBaloons--;
                tempCoordinates.Y--;
            }

            tempCoordinates.X = currentPosition.X;
            tempCoordinates.Y = currentPosition.Y + 1;
            while (currentBaloon == GetBaloon(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                this.RemainingBaloons--;
                tempCoordinates.Y++;
            }

            this.ShootCounter++;
            LandFlyingBaloons();
        }

        private char GetBaloon(Coordinates currentPosition)
        {
            // TODO: extract validator
            bool isOutOfBoard = currentPosition.X < 0
                || currentPosition.Y < 0
                || currentPosition.X > GlobalConstants.BALLOONS_BOARD_COLS - 1
                || currentPosition.Y > GlobalConstants.BALLOONS_BOARD_ROWS - 1;

            if (isOutOfBoard)
            {
                return 'e';
            }

            int xPosition = 4 + (currentPosition.X * 2);
            int yPosition = 2 + currentPosition.Y;
            return field[xPosition, yPosition];
        }

        private void Swap(Coordinates currentPosition, Coordinates newPosition)
        {
            char tmp = GetBaloon(currentPosition);
            AddNewBaloonToGameBoard(currentPosition, GetBaloon(newPosition));
            AddNewBaloonToGameBoard(newPosition, tmp);
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
                    if (GetBaloon(currentPosition) == '.')
                    {
                        for (int k = row; k > 0; k--)
                        {
                            Coordinates tempCoordinates = new Coordinates();
                            Coordinates tempCoordinates1 = new Coordinates();
                            tempCoordinates.X = column;
                            tempCoordinates.Y = k;
                            tempCoordinates1.X = column;
                            tempCoordinates1.Y = k - 1;
                            Swap(tempCoordinates, tempCoordinates1);
                        }
                    }
                }
            }
        }

        private void AddNewBaloonToGameBoard(Coordinates currentPosition, char baloonValue)
        {
            int xPosition = 4 + (currentPosition.X * 2);
            int yPosition = 2 + currentPosition.Y;
            this.field[xPosition, yPosition] = baloonValue;
        }

        // TODO: get rid of all magic numbers
    }
}