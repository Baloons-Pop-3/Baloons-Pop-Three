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
        IGenericRepository<Game> games = new TxtFileRepository<Game>(GlobalConstants.GAMES_PATH);
        // TODO: implement logic for saving games(this is the repository used for)    

        GameField field = new GameField(
            GlobalConstants.GAME_BOARD_ROWS,
            GlobalConstants.GAME_BOARD_COLS,
            GlobalConstants.BALLOONS_BOARD_COLS,
            GlobalConstants.BALLOONS_BOARD_ROWS);
        IReader reader = new ConsoleReader();
        IPrinter printer = new ConsolePrinter();
        Game balloonsGame;
        GameLogic gameLogic;
        IBalloonsData db;
        IGameBoardEngine engine;


        public void Start()
        {
            this.balloonsGame = new Game(this.field);
            this.gameLogic = new GameLogic(this.balloonsGame);
            this.db = new BalloonsData(this.players, this.games);
            this.engine = new GameBoardEngine(this.gameLogic, this.printer, this.reader, this.db);

            this.engine.Init();
        }
    }
}
