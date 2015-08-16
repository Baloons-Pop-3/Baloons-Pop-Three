namespace BalloonsPops
{
    using System;
    using System.Collections.Generic;

    internal class PersonScoreComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return x.Score.CompareTo(y.Score);
        }
    }
}
