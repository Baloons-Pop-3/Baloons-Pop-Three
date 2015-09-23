using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop
{
    using Common;

    class GameField
    {
        private int fieldRows;
        private int fieldCols;
        private int balloonsCols;
        private int balloonsRows;

        private char[,] field;

        public GameField(int fieldCols, int fieldRows, int balloonCols,int balloonRows)
        {
            this.FieldCols = fieldCols;
            this.FieldRows = fieldRows;
            this.BalloonsCols = balloonCols;
            this.BalloonsRows = balloonRows;
            this.field = new char[this.FieldRows, this.FieldCols];

            this.FillField();
        }

        public int FieldRows
        {
            get
            {
                return this.fieldRows;
            }
            private set
            {
                this.fieldRows = value;
            }
        }

        public int FieldCols
        {
            get
            {
                return this.fieldCols;
            }
            private set
            {
                this.fieldCols = value;
            }
        }

        public int BalloonsRows
        {
            get
            {
                return this.balloonsRows;
            }
            private set
            {
                this.balloonsRows = value;
            }
        }

        public int BalloonsCols
        {
            get
            {
                return this.balloonsCols;
            }
            private set
            {
                this.balloonsCols = value;
            }
        }

        public char this[int row, int col]
        {
            get
            {
                if (col < 0 || col > this.FieldCols - 1 || row < 0 || row > this.FieldRows - 1)
                {
                    throw new IndexOutOfRangeException("There is no such index!");
                }
                else
                {
                    return this.field[row, col];
                }
            }
            set
            {
                if (col < 0 || col > this.FieldCols - 1 || row < 0 || row > this.FieldRows - 1)
                {
                    throw new IndexOutOfRangeException("There is no such index!");
                }
                else
                {
                    this.field[row, col] = value;
                }
            }
        }

        public char[,] GetField()
        {
            return this.field;
        }

        // TODO: Refactor magic numbers
        public void UpdateField(Coordinates currentPosition, char baloonValue)
        {
            int xPosition = 4 + (currentPosition.X * 2);
            int yPosition = 2 + currentPosition.Y;
            this.field[xPosition, yPosition] = baloonValue;
        }

        private void FillField()
        {
            for (int i = 0; i < this.FieldCols; i++)
            {
                for (int j = 0; j < this.FieldRows; j++)
                {
                    field[j, i] = ' ';
                }
            }

            //printing numbers of the columns
            for (int i = 0; i < 4; i++)
            {
                field[i, 0] = ' ';
            }

            char counter = '0';

            for (int i = 4; i < 25; i++)
            {
                if ((i % 2 == 0) && counter <= '9')
                {
                    field[i, 0] = counter++;
                }
                else
                {
                    field[i, 0] = ' ';
                }
            }

            //printing up game board wall
            for (int i = 3; i < 24; i++)
            {
                field[i, 1] = '-';
            }

            //printing left game board wall
            counter = '0';

            for (int i = 2; i < 8; i++)
            {
                if (counter <= '4')
                {
                    field[0, i] = counter++;
                    field[1, i] = ' ';
                    field[2, i] = '|';
                    field[3, i] = ' ';
                }
            }

            //printing down game board wall
            for (int i = 3; i < 24; i++)
            {
                field[i, 7] = '-';
            }

            //printing right game board wall
            for (int i = 2; i < 7; i++)
            {
                field[24, i] = '|';
            }

            this.FillWithBalloons();
        }

        private void FillWithBalloons()
        {
            Random random = new Random();
            Coordinates currentPosition = new Coordinates();
            for (int column = 0; column < this.BalloonsCols; column++)
            {
                for (int row = 0; row < this.BalloonsRows; row++)
                {
                    currentPosition.X = column;
                    currentPosition.Y = row;

                    this.UpdateField(currentPosition, (char)(random.Next(1, 5) + (int)'0'));
                }
            }
        }
    }
}
