using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop.Drawer
{
    class ConsoleGameBoardDrawer : IGameBoardDrawer
    {
        public char[,] DrawGameBoard(GameBoard gb)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    gb.Field[j, i] = ' ';
                }
            }

            //printing numbers of the columns
            for (int i = 0; i < 4; i++)
            {
                gb.Field[i, 0] = ' ';
            }

            char counter = '0';

            for (int i = 4; i < 25; i++)
            {
                if ((i % 2 == 0) && counter <= '9')
                {
                    gb.Field[i, 0] = counter++;
                }
                else
                {
                    gb.Field[i, 0] = ' ';
                }
            }

            //printing up game board wall
            for (int i = 3; i < 24; i++)
            {
                gb.Field[i, 1] = '-';
            }

            //printing left game board wall
            counter = '0';

            for (int i = 2; i < 8; i++)
            {
                if (counter <= '4')
                {
                    gb.Field[0, i] = counter++;
                    gb.Field[1, i] = ' ';
                    gb.Field[2, i] = '|';
                    gb.Field[3, i] = ' ';
                }
            }

            //printing down game board wall
            for (int i = 3; i < 24; i++)
            {
                gb.Field[i, 7] = '-';
            }

            //printing right game board wall
            for (int i = 2; i < 7; i++)
            {
                gb.Field[24, i] = '|';
            }

            gb.GenerateBalloons();

            return gb.Field;
        }
    }
}
