namespace BalloonsPop
{
    using Models.Contracts;
    using Common;
    using System;

    class GameField:IPrototype<GameField>
    {
        private char[,] field;

        public GameField(int fieldRows,int fieldCols)
        {
            this.FieldRows = fieldRows;
            this.FieldCols = fieldCols;
            this.field = new char[this.FieldRows, this.FieldCols];

            this.FillWithBalloons();
        }

        //TODO: validations for negative values
        public int FieldRows { private set; get; }

        public int FieldCols { private set; get; }

        public char this[int row, int col]
        {
            get
            {
                if (col < 0 || col > this.FieldCols - 1 || row < 0 || row > this.FieldRows - 1)
                {
                    throw new IndexOutOfRangeException(GlobalMessages.INVALID_INDEX_OF_FIELD);
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
                    throw new IndexOutOfRangeException(GlobalMessages.INVALID_INDEX_OF_FIELD);
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

        public void UpdateField(Coordinates currentPosition, char baloonValue)
        {
            this.field[currentPosition.X, currentPosition.Y] = baloonValue;
        }

        public void FillWithBalloons()
        {
            Random random = new Random();
            Coordinates currentPosition = new Coordinates();
            for (int row = 0; row < this.FieldRows; row++)
            {
                for (int column= 0; column < this.FieldCols; column++)
                {
                    currentPosition.X = row;
                    currentPosition.Y = column;

                    this.UpdateField(
                        currentPosition, 
                        (char)(random.Next((int)BallonType.First - (int)'0', (int)BallonType.Fifth - (int)'0') + (int)'0'));
                }
            }
        }

        public GameField Clone()
        {
            var clone= new GameField(this.FieldRows, this.FieldCols);

            for (int i = 0; i < clone.FieldRows; i++)
            {
                for (int j = 0; j < clone.FieldCols; j++)
                {
                    clone[i, j] = this.field[i, j];
                }
            }

            return clone;
        }

    }
}
