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
            //Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            //DrawGameBoard();
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
                Console.WriteLine("Illegal move: cannot pop missing ballon!"); return;
            }

            AddNewBaloonToGameBoard(currentPosition, '.');
            this.RemainingBaloons--;

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

        public bool ReadInput(out bool isCoordinates, ref Coordinates coordinates, ref Command command)
        {
            Console.Write("Enter a row and column: ");
            string consoleInput = Console.ReadLine();

            coordinates = new Coordinates();
            command = new Command();

            if (Command.IsValidCommand(consoleInput))
            {
                isCoordinates = false;
                command.Type = Command.GetType(consoleInput);
                return true;
            }
            else if (coordinates.TryParse(consoleInput, ref coordinates))
            {
                isCoordinates = true;
                return true;
            }
            else
            {
                isCoordinates = false;
                return false;
            }
        }

        private char GetBaloon(Coordinates currentPosition)
        {
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

        //private void DrawGameBoard()
        //{
        //    //printing blank spaces
        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 25; j++)
        //        {
        //            field[j, i] = ' ';
        //        }
        //    }

        //    //printing numbers of the columns
        //    for (int i = 0; i < 4; i++)
        //    {
        //        field[i, 0] = ' ';
        //    }

        //    char counter = '0';

        //    for (int i = 4; i < 25; i++)
        //    {
        //        if ((i % 2 == 0) && counter <= '9')
        //        {
        //            field[i, 0] = counter++;
        //        }
        //        else
        //        {
        //            field[i, 0] = ' ';
        //        }
        //    }

        //    //printing up game board wall
        //    for (int i = 3; i < 24; i++)
        //    {
        //        field[i, 1] = '-';
        //    }

        //    //printing left game board wall
        //    counter = '0';

        //    for (int i = 2; i < 8; i++)
        //    {
        //        if (counter <= '4')
        //        {
        //            field[0, i] = counter++;
        //            field[1, i] = ' ';
        //            field[2, i] = '|';
        //            field[3, i] = ' ';
        //        }
        //    }

        //    //printing down game board wall
        //    for (int i = 3; i < 24; i++)
        //    {
        //        field[i, 7] = '-';
        //    }

        //    //printing right game board wall
        //    for (int i = 2; i < 7; i++)
        //    {
        //        field[24, i] = '|';
        //    }
        //}

        //public void PrintGameBoard()
        //{
        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 25; j++)
        //        {
        //            Console.Write(field[j, i]);
        //        }

        //        Console.WriteLine();
        //    }

        //    Console.WriteLine();
        //}
    }
}