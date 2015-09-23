namespace BalloonsPop.Engine
{
    using Drawer;
    using Printer;
    using Reader;

    interface IGameBoardEngine
    {
        GameBoard GameBoard { get; set; }

        IGameBoardDrawer Drawer { get; set; }

        IPrinter Printer { get; set; }

        IReader Reader { get; set; }

        void Init();
    }
}
