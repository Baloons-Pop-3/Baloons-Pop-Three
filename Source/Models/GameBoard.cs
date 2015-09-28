namespace BalloonsPop.Models
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class GameBoard
    {

        public GameBoard(GameField gameField)
        {
            this.BoardRows = gameField.FieldRows + 3;
            this.BoardCols = gameField.FieldCols + 15;

            this.Board = new char[this.BoardRows, this.BoardCols];
            this.Field = gameField.GetField();

            this.FillGameBoard();
        }

        public char[,] Board { private set; get; }

        public char[,] Field { private set; get; }

        //TODO: validations for negative values
        public int BoardRows { private set; get; }

        public int BoardCols { private set; get; }

        public char this[int row, int col]
        {
            get
            {
                if (col < 0 || col > this.BoardCols - 1 || row < 0 || row > this.BoardRows - 1)
                {
                    throw new IndexOutOfRangeException(GlobalMessages.INVALID_INDEX_OF_FIELD);
                }
                else
                {
                    return this.Board[row, col];
                }
            }
            set
            {
                if (col < 0 || col > this.BoardCols - 1 || row < 0 || row > this.BoardRows - 1)
                {
                    throw new IndexOutOfRangeException(GlobalMessages.INVALID_INDEX_OF_FIELD);
                }
                else
                {
                    this.Board[row, col] = value;
                }
            }
        }

        public char[,] GetField()
        {
            return this.Board;
        }

        private void FillGameBoard() {
            int counter = 0;
            char number = '0';

            for (int i = 4; i < this.BoardCols; i++)
            {
                if ((i % 2 == 0) && counter <= this.Field.GetLength(1)-1)
                {
                    this.Board[0,i] = number++;
                    counter++;
                }
                else
                {
                    this.Board[0,i] = ' ';
                }
            }

            //printing up game board wall
            for (int i = 3; i < this.BoardCols-1; i++)
            {
                this.Board[1, i] = '-';
            }

            //printing left game board wall
             counter = 0;
             number = '0';

            for (int i = 2; i < this.BoardRows; i++)
            {
                if (counter <= this.Field.GetLength(0)-1)
                {
                    this.Board[i, 0] = number++;
                    this.Board[i, 1] = ' ';
                    this.Board[i, 2] = '|';
                    this.Board[i, 3] = ' ';
                    counter++;
                }
            }

            //printing down game board wall
            for (int i = 3; i < this.BoardCols-1; i++)
            {
                this.Board[this.BoardRows-1, i] = '-';
            }

            //printing right game board wall
            for (int i = 2; i < this.BoardRows - 1; i++)
            {
                this.Board[i, this.BoardCols - 1] = '|';
            }

            var row = 0;
            var col = 0;

            for (int i = 2; i < this.BoardRows-1; i++)
            {
                for (int j = 4; j <this.BoardCols-1; j+=2)
                {
                    this.Board[i, j] = this.Field[row, col];
                    col++;
                }
                row++;
                col = 0;
            }
        }


    }
}
