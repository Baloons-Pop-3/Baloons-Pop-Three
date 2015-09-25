﻿using System;
using BalloonsPop.Data;
using BalloonsPop.Printer;
using BalloonsPop.Reader;
using BalloonsPop.TopScoreBoard;

namespace BalloonsPop.Engine
{
    class GameBoardEngine : IGameBoardEngine
    {
        public GameBoardEngine(GameLogic gameLogic, IPrinter printer,IReader reader,IBalloonsData db)
        {
            this.GameLogic = gameLogic;
            this.Printer = printer;
            this.Reader = reader;
            this.DataBase = db;
        }

        public IBalloonsData DataBase { get; private set; }

        public GameLogic GameLogic{ get; private set; }

        public IPrinter Printer { get; private set; }

        public IReader Reader { get; private set; }

        public void Init()
        {
            this.Printer.PrintMessage("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            this.Printer.PrintGameBoard(this.GameLogic.Game.Field.GetField());

            this.StartGame();
        }

        private void StartGame()
        {
            TopScore ts = new TopScore();
            Coordinates coordinates = new Coordinates();
            Command command = new Command();

            ts.OpenTopScoreList();

            while (this.GameLogic.Game.RemainingBaloons > 0)
            {
                Printer.PrintMessage("Enter a row and column: ");
                var input = Reader.ReadInput();

                if (Command.IsValidCommand(input))
                {
                    command.Type = Command.GetType(input);

                    switch (command.Type)
                    {
                        case CommandType.Top:
                            {
                                ts.PrintScoreList();
                            }
                            break;
                        case CommandType.Restart:
                            {
                                this.Init();
                                this.Printer.PrintGameBoard(this.GameLogic.Game.Field.GetField());
                            }
                            break;
                        case CommandType.Exit:
                            {
                                return;
                            }
                    }
                }
                else if (coordinates.TryParse(input))
                {
                    try
                    {
                        this.GameLogic.ShootBalloonAtPosition(coordinates);
                    }
                    catch (ArgumentException ex)
                    {
                        Printer.PrintMessage(ex.Message);
                    }

                    this.Printer.PrintGameBoard(this.GameLogic.Game.Field.GetField());
                }
                else
                {
                   Printer.PrintMessage("Invalid move or command!");
                }
            }

            // TODO: Refactor the logic about topScore
            Player player = new Player();
            player.Score = this.GameLogic.Game.ShootCounter;

            if (ts.IsTopScore(player))
            {
                Printer.PrintMessage("Please enter your name for the top scoreboard: ");
                player.Name = Reader.ReadInput();
                ts.AddToTopScoreList(player);
            }
            ts.SaveTopScoreList();
        }

    }
}
