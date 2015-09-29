namespace BalloonsPop.Commands
{
    using Contexts;

    class StartCommand:ICommand
    {
        public StartCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public void Execute()
        {
            this.Context.Printer.PrintMessage("How dificult do you want it: Your options are:\neasy\nmedium\nhard");
            var input=this.Context.Reader.ReadInput();
            GameField gamefield;

            if (input == "easy")
            {
                gamefield = new GameField(5, 5);
                this.Context.GameLogic.Game = new Game(gamefield);
            }
            else if(input == "medium")
            {
                gamefield = new GameField(8, 8);
                this.Context.GameLogic.Game = new Game(gamefield);
            }
            else if (input == "hard")
            {
                gamefield = new GameField(10, 10);
                this.Context.GameLogic.Game = new Game(gamefield);
            }

            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}
