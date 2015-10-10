namespace BalloonsPop.Tests
{
    using Factories;
    using Factories.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    class CommandFactoryTests
    {
        private readonly ICommandFactory factory;

        public CommandFactoryTests()
        {
            this.factory = new CommandFactory();
        }
    }
}
