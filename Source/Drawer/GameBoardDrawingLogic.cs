namespace BalloonsPop.Models
{
    using Drawer;
    using Common;
    using System;

    class GameBoardDrawingLogic:IGameBoardDrawingLogic
    {
        public GameBoardDrawingLogic(GameField gameField)
        {
            this.Board = new char[gameField.FieldRows+3, gameField.FieldCols + 15];
            this.Field = gameField.GetField();

            this.DrawGameBoard();
        }

        //TODO: validations for negative values
        public char[,] Board {  private set; get; }

        private char[,] Field {  set; get; }

        private void DrawGameBoard() {
            int counter = 0;
            char number = '0';

            for (int i = 4; i < this.Board.GetLength(1); i++)
            {
                if ((i % 2 == 0) && counter <= this.Field.GetLength(1)-1)
                {
                    this.Board[0,i] = number++;
                    counter++;
                }

            }

            //printing up game board wall
            for (int i = 3; i < this.Board.GetLength(1) - 1; i++)
            {
                this.Board[1, i] = '-';
            }

            //printing left game board wall
             counter = 0;
             number = '0';

            for (int i = 2; i < this.Board.GetLength(0); i++)
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
            for (int i = 3; i < this.Board.GetLength(1) - 1; i++)
            {
                this.Board[this.Board.GetLength(0) - 1, i] = '-';
            }

            //printing right game board wall
            for (int i = 2; i < this.Board.GetLength(0) - 1; i++)
            {
                this.Board[i, this.Board.GetLength(1) - 1] = '|';
            }

            var row = 0;
            var col = 0;

            for (int i = 2; i < this.Board.GetLength(0) - 1; i++)
            {
                for (int j = 4; j <this.Board.GetLength(1) - 1; j+=2)
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
