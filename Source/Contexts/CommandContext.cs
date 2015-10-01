namespace BalloonsPop.Contexts
{
    using BalloonsPop.Data;
    using BalloonsPop.Mementos;
    using BalloonsPop.Printer;
    using BalloonsPop.Reader;
    using BalloonsPop.TopScoreBoard;

    internal class CommandContext : ICommandContext
    {
        public CommandContext(IBalloonsData data, GameLogic logic, IGamePrinter printer, IReader reader, ITopScore topScore)
        {
            this.DataBase = data;
            this.GameLogic = logic;
            this.Printer = printer;
            this.Reader = reader;
            this.TopScore = topScore;

            this.Memory = new GameStateMemory();
        }

        public IBalloonsData DataBase { private set; get; }

        public GameLogic GameLogic { private set; get; }

        public IGamePrinter Printer { private set; get; }

        public IReader Reader { private set; get; }

        public ITopScore TopScore { private set; get; }

        public GameStateMemory Memory { set; get; }
    }
}