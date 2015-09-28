using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Mementos
{
    class GameMemento
    {
        public GameField Field { get; set; }

        public int ShootCounter { get; set; }

        public int RemainingBalloons { get; set; }

        public  GameMemento(GameField field, int shootCounter, int remainingBallons)
        {
            this.Field = field.Clone();
            this.ShootCounter = shootCounter;
            this.RemainingBalloons = remainingBallons;
        }
    }
}
