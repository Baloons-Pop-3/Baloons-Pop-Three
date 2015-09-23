namespace BalloonsPop.Engine
{
    using Printer;
    using Reader;

    interface IGameBoardEngine
    {
        GameModel GameBoard { get; set; }

        IPrinter Printer { get; set; }

        IReader Reader { get; set; }

        void Init();
    }
}
