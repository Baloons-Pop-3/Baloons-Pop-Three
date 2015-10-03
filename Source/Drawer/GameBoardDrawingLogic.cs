namespace BalloonsPop.Drawer
{
    using BalloonsPop.Drawer.Contracts;
    using BalloonsPop.Models;
    using Drawer;

    internal class GameBoardDrawingLogic : IGameBoardDrawingLogic
    {
        public GameBoardDrawingLogic(GameField gameField)
        {
            this.Board = new string[(gameField.FieldRows + 3), (gameField.FieldCols + 4)];
            this.Field = gameField.GetField();

            this.DrawGameBoard();
        }

        // TODO: validations for negative values
        public string[,] Board { get; private set; }

        private char[,] Field { get; set; }

        private void DrawGameBoard()
        {
            // printing cols numeration
            int counter = 0;
            int number = 0;

            for (int i = 4; i < this.Board.GetLength(1); i++)
            {
                if (counter <= this.Field.GetLength(1) - 1)
                {
                    if (number == 0)
                    {
                        this.Board[0, i] = "     " + (number++).ToString();
                    }
                    else if (number + 1 <= 10)
                    {
                        this.Board[0, i] = "  " + (number++).ToString();
                    }
                    else
                    {
                        this.Board[0, i] = " " + (number++).ToString();
                    }

                    counter++;
                }
            }

            // printing up game board wall
            for (int i = 3; i < this.Board.GetLength(1); i++)
            {
                this.Board[1, i] = " - ";
            }

            // printing left game board wall and  rows numeration
            counter = 0;
            number = 0;

            for (int i = 2; i < this.Board.GetLength(0); i++)
            {
                if (counter <= this.Field.GetLength(0) - 1)
                {
                    if (number + 1 <= 10)
                    {
                        this.Board[i, 0] = ' ' + (number++).ToString();
                    }
                    else
                    {
                        this.Board[i, 0] = (number++).ToString();
                    }

                    this.Board[i, 1] = " ";
                    this.Board[i, 2] = "|";
                    this.Board[i, 3] = " ";
                    counter++;
                }
            }

            // printing down game board wall
            for (int i = 3; i < this.Board.GetLength(1); i++)
            {
                this.Board[this.Board.GetLength(0) - 1, i] = " - ";
            }

            // printing right game board wall
            for (int i = 2; i < this.Board.GetLength(0) - 1; i++)
            {
                this.Board[i, this.Board.GetLength(1) - 1] = "|";
            }

            // filling the board with balloons
            var row = 0;
            var col = 0;

            for (int i = 2; i < this.Board.GetLength(0) - 1; i++)
            {
                for (int j = 3; j < this.Board.GetLength(1) - 1; j++)
                {
                    this.Board[i, j] = " " + this.Field[row, col].ToString() + " ";
                    col++;
                }

                row++;
                col = 0;
            }
        }
    }
}