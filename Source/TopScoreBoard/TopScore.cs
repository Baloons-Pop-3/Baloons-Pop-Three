namespace BalloonsPop.TopScoreBoard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    // TODO: Global refactor
    // TODO: Implement ITopScore
    public class TopScore
    {
        private const string scorePath = "..\\..\\Data\\TopScore.txt";
        public const int MAX_TOP_SCORE_COUNT = 5;
        List<Player> topScoreList = new List<Player>();

        public bool IsTopScore(Player person)
        {
            if (topScoreList.Count >= MAX_TOP_SCORE_COUNT)
            {
                topScoreList.Sort((p1, p2) => p1.CompareTo(p2));
                if (topScoreList[MAX_TOP_SCORE_COUNT - 1] > person)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public void AddToTopScoreList(Player person)
        {
            topScoreList.Add(person);
            topScoreList.Sort((p1, p2) => p1.CompareTo(p2));
            while (topScoreList.Count > 5)
            {
                topScoreList.RemoveAt(5);
            }
        }

        public void OpenTopScoreList()
        {
            using (StreamReader TopScoreStreamReader = new StreamReader(scorePath))
            {
                string line = TopScoreStreamReader.ReadLine();
                while (line != null)
                {
                    char[] separators = { ' ' };
                    string[] substrings = line.Split(separators);
                    int substringsCount = substrings.Count<string>();
                    if (substringsCount > 0)
                    {
                        Player player = new Player();
                        player.Name = substrings[1];
                        player.Score = int.Parse(substrings[substringsCount - 2]);
                        topScoreList.Add(player);
                    }
                    line = TopScoreStreamReader.ReadLine();
                }
            }
        }

        public void SaveTopScoreList()
        {
            if (topScoreList.Count > 0)
            {
                string toWrite = "";
                using (StreamWriter TopScoreStreamWriter = new StreamWriter(scorePath))
                {
                    for (int i = 0; i < topScoreList.Count; i++)
                    {
                        toWrite += i.ToString() + ". " + topScoreList[i].Name + " --> " + topScoreList[i].Score.ToString() + " moves";
                        TopScoreStreamWriter.WriteLine(toWrite);
                        toWrite = "";
                    }
                }
            }
            PrintScoreList();
        }

        public void PrintScoreList()
        {
            Console.WriteLine("Scoreboard:");
            if (topScoreList.Count > 0)
            {
                for (int i = 0; i < topScoreList.Count; i++)
                {
                    Console.WriteLine(i.ToString() + ". " + topScoreList[i].Name + " --> " + topScoreList[i].Score.ToString() + "moves");
                }
            }
            else
            {
                Console.WriteLine("Scoreboard is empty");
            }
        }
    }
}