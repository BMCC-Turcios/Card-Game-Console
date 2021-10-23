using System;
using System.Collections.Generic;
using System.IO;


namespace CardGame
{
    public class IOScore
    {
        public string filePath { get; private set; }
        const int MAX_SCORE_WRITE = 8;
        public IOScore(int gameType)
        {
            string workingDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            filePath = $"{workingDirectory}{gameType}_leaderboard.txt";

            

        }

        public void SaveLeaderBoard(Dictionary<string, int> newLeaderboard)
        {
            using StreamWriter fileWriter = new StreamWriter(filePath);
            foreach (var line in newLeaderboard)
            {
                fileWriter.WriteLine(line.Key + ":" + line.Value.ToString());
            }
            fileWriter.Close();


        }
        public Dictionary<string, int> GetLeaderBoard()
        {
            Dictionary<string, int> leaderboard = new Dictionary<string, int>();
            if (File.Exists(filePath))
            {
                string line = "";
                string token = ":";
                string[] leaderboardInfo;
                using StreamReader readFile = new StreamReader(filePath);
                line = readFile.ReadLine();
                while (line != null)
                {
                    leaderboardInfo = line.Split(token);
                    leaderboard.Add(leaderboardInfo[0], Int32.Parse(leaderboardInfo[1]));
                    line = readFile.ReadLine();
                }
            }

            return leaderboard;
                
        }


    }
}
