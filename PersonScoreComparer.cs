namespace BalloonsPops
{
    using System;
    using System.Collections.Generic;

    internal class PersonScoreComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Score.CompareTo(y.Score);
        }
    }
}
