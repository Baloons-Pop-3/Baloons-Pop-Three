namespace BalloonsPop
{
    using Common;
    using Reader;
    using Printer;
    using Engine;
    using Data;

    public class GameFacade
    {

        IGenericRepository<Player> players = new TxtFileRepository<Player>(GlobalConstants.TOP_SCORE_PATH);
        IGenericRepository<GameModel> games = new TxtFileRepository<GameModel>(GlobalConstants.GAMES_PATH);
        // TODO: implement logic for saving games(this is the repository used for)    

        GameField field = new GameField(
            GlobalConstants.GAME_BOARD_ROWS,
            GlobalConstants.GAME_BOARD_COLS,
            GlobalConstants.BALLOONS_BOARD_COLS,
            GlobalConstants.BALLOONS_BOARD_ROWS);
        IReader reader = new ConsoleReader();
        IPrinter printer = new ConsolePrinter();
        GameModel gameBoard;
        IGameBoardEngine engine;
        IBalloonsData db;

        public void Start()
        {
            this.gameBoard = new GameModel(field);
            this.db = new BalloonsData(players, games);
            this.engine = new GameBoardEngine(gameBoard, printer, reader, db);

            this.engine.Init();
        }
    }
}
