namespace BalloonsPop
{
    using System;

    class GameBoard
    {
        const int initialBaloonsNumber = 50;

        char[,] gameBoard = new char[25, 8];
        private int shootCount = 0;
        private int remainingBaloonsCounter = initialBaloonsNumber;

        public int ShootCounter
        {
            get
            {
                return this.shootCount;
            }
        }

        public int RemainingBaloons
        {
            get
            {
                return this.remainingBaloonsCounter;
            }
        }

        public void GenerateNewGame()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            remainingBaloonsCounter = initialBaloonsNumber;
            FillBlankGameBoard();
            Random random = new Random();
            Coordinates currentPosition = new Coordinates();
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    currentPosition.X = row;
                    currentPosition.Y = column;

                    AddNewBaloonToGameBoard(currentPosition, (char)(random.Next(1, 5) + (int)'0'));
                }
            }
        }

        private void AddNewBaloonToGameBoard(Coordinates currentPosition, char baloonValue)
        {
            int xPosition = 4 + currentPosition.X * 2;
            int yPosition = 2 + currentPosition.Y;
            gameBoard[xPosition, yPosition] = baloonValue;
        }

        private char get(Coordinates currentPosition)
        {
            if (currentPosition.X < 0 || currentPosition.Y < 0 || currentPosition.X > 9 || currentPosition.Y > 4) return 'e';
            int xPosition = 4 + currentPosition.X * 2;
            int yPosition = 2 + currentPosition.Y;
            return gameBoard[xPosition, yPosition];
        }

        private void FillBlankGameBoard()
        {
            //printing blank spaces
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 25; column++)
                {
                    gameBoard[column, row] = ' ';
                }
            }

            //printing firs row
            for (int column = 0; column < 4; column++)
            {
                gameBoard[column, 0] = ' ';
            }

            char counter = '0';


            for (int i = 4; i < 25; i++)
            {
                if ((i % 2 == 0) && counter <= '9')
                {
                    gameBoard[i, 0] = (char)counter++;
                }
                else
                {
                    gameBoard[i, 0] = ' ';
                }
            }

            //printing second row
            for (int column = 3; column < 24; column++)
            {
                gameBoard[column, 1] = '-';
            }


            //printing left game board wall
            counter = '0';

            for (int i = 2; i < 8; i++)
            {
                if (counter <= '4')
                {
                    gameBoard[0, i] = counter++;
                    gameBoard[1, i] = ' ';


                    gameBoard[2, i] = '|';
                    gameBoard[3, i] = ' ';
                }
            }

            //printing down game board wall
            for (int i = 3; i < 24; i++)
            {
                gameBoard[i, 7] = '-';
            }

            //printing right game board wall
            for (int i = 2; i < 7; i++)
            {
                gameBoard[24, i] = '|';
            }
        }

        public void PrintGameBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    Console.Write(gameBoard[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Shoot(Coordinates currentPosition)
        {
            char currentBaloon;
            currentBaloon = get(currentPosition);
            Coordinates tempCoordinates = new Coordinates();

            if (currentBaloon < '1' || currentBaloon > '4')
            {
                Console.WriteLine("Illegal move: cannot pop missing ballon!"); return;
            }



            AddNewBaloonToGameBoard(currentPosition, '.');
            remainingBaloonsCounter--;

            tempCoordinates.X = currentPosition.X - 1;
            tempCoordinates.Y = currentPosition.Y;
            while (currentBaloon == get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                remainingBaloonsCounter--;
                tempCoordinates.X--;
            }

            tempCoordinates.X = currentPosition.X + 1; tempCoordinates.Y = currentPosition.Y;
            while (currentBaloon == get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                remainingBaloonsCounter--;
                tempCoordinates.X++;
            }

            tempCoordinates.X = currentPosition.X;
            tempCoordinates.Y = currentPosition.Y - 1;
            while (currentBaloon == get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                remainingBaloonsCounter--;
                tempCoordinates.Y--;
            }

            tempCoordinates.X = currentPosition.X;
            tempCoordinates.Y = currentPosition.Y + 1;
            while (currentBaloon == get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                remainingBaloonsCounter--;
                tempCoordinates.Y++;
            }

            shootCount++;
            LandFlyingBaloons();
        }

        private void Swap(Coordinates currentPosition, Coordinates c1)
        {
            char tmp = get(currentPosition);
            AddNewBaloonToGameBoard(currentPosition, get(c1));
            AddNewBaloonToGameBoard(c1, tmp);
        }

        private void LandFlyingBaloons()
        {
            Coordinates currentPosition = new Coordinates();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    currentPosition.X = i;
                    currentPosition.Y = j;
                    if (get(currentPosition) == '.')
                    {
                        for (int k = j; k > 0; k--)
                        {
                            Coordinates tempCoordinates = new Coordinates();
                            Coordinates tempCoordinates1 = new Coordinates();
                            tempCoordinates.X = i;
                            tempCoordinates.Y = k;
                            tempCoordinates1.X = i;
                            tempCoordinates1.Y = k - 1;
                            Swap(tempCoordinates, tempCoordinates1);
                        }
                    }
                }
            }
        }

        public bool ReadInput(out bool IsCoordinates, ref Coordinates coordinates, ref Command command)
        {
            Console.Write("Enter a row and column: ");
            string consoleInput = Console.ReadLine();

            coordinates = new Coordinates();
            command = new Command();

            if (Command.IsValidCommand(consoleInput))
            {
                IsCoordinates = false;
                command.Type = Command.GetType(consoleInput);
                return true;
            }
            else if (Coordinates.TryParse(consoleInput, ref coordinates))
            {
                IsCoordinates = true;
                return true;
            }
            else
            {
                IsCoordinates = false;
                return false;
            }
        }
    }
}