using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop
{
    // veche pisha na c#, uraaaaaaaaaaaaaaa, mnogo e yako tova be!
    class Balloons
    {
        static void Main(string[] args)
        {
            GameBoard gb = new GameBoard();
            gb.GenerateNewGame();
            gb.PrintGameBoard();
            TopScore ts = new TopScore();

            ts.OpenTopScoreList();

            bool isCoordinates;
            Coordinates coordinates = new Coordinates();
            Command command = new Command();
            while (gb.RemainingBaloons > 0)
            {
                if (gb.ReadInput(out isCoordinates, ref coordinates, ref command))
                {
                    if (isCoordinates)
                    {
                        gb.Shoot(coordinates);
                        gb.PrintGameBoard();
                    }
                    else
                    {
                        switch (command.Type)
                        {
                            case CommandType.Top:
                                {
                                    ts.PrintScoreList();
                                }
                                break;
                            case CommandType.Restart:
                                {
                                    gb.GenerateNewGame();
                                    gb.PrintGameBoard();
                                }
                                break;
                            case CommandType.Exit:
                                {
                                    return;
                                }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Input!");
                }
            }

            Player player = new Player();
            player.Score = gb.ShootCounter;

            if (ts.IsTopScore(player))
            {
                Console.WriteLine("Please enter your name for the top scoreboard: ");
                player.Name = Console.ReadLine();
                ts.AddToTopScoreList(player);
            }
            ts.SaveTopScoreList();
        }
    }
}
