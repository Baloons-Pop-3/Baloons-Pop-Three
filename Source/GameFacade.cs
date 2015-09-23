using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop
{
    using Common;
    using Reader;
    using Printer;
    using Engine;
    public class GameFacade
    {
        GameField field = new GameField(
            GlobalConstants.GAME_BOARD_ROWS,
            GlobalConstants.GAME_BOARD_COLS,
            GlobalConstants.BALLOONS_BOARD_COLS,
            GlobalConstants.BALLOONS_BOARD_ROWS);
        IReader reader = new ConsoleReader();
        IPrinter printer = new ConsolePrinter();
        GameModel gameBoard;
        IGameBoardEngine engine;

        public void Start()
        {
            this.gameBoard = new GameModel(field);
            this.engine = new GameBoardEngine(gameBoard, printer, reader);

            this.engine.Init();
        }
    }
}
