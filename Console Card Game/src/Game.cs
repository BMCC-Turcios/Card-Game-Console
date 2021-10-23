using System;
using System.Collections.Generic;

namespace CardGame
{
    abstract public class Game : Board
    {
        /// <summary>
        /// Game Ten board size is 13
        /// </summary>
        public const int TEN = 10;
        /// <summary>
        /// Game Eleven board size is 11
        /// </summary>
        public const int ELEVEN = 11;
        /// <summary>
        /// Game Thirteenis board size is 10
        /// </summary>
        public const int THIRTEEN = 13;

        public Dictionary<string, int> Leaderboard { get; private set; }
        public string PlayerName { get; private set; }
        /// <summary>
        /// Gets the boolean value if the player has surrenered 
        /// </summary>
        public bool HasSurrendered { get; private set; }
        /// <summary>
        /// gets the type of game
        /// </summary>
        public abstract int GameType { get; }
        protected Game(int sizeOfBoard) : base(sizeOfBoard) 
        {
            PlayerName = "PLAYER";
            Leaderboard = new IOScore(GameType).GetLeaderBoard();
        }

        /// <summary>
        /// Factory method that creates an instancei of a subclass of game
        /// </summary>
        /// <param name="gameType">The type of game the player wants to play</param>
        /// <returns>Subclass Game Object</returns>
        public static Game Create(string gameType)
        {
            switch (gameType.ToUpper())
            {
                case "TEN":
                    return new Ten();
                case "ELEVEN":
                    return new Eleven();
                case "THIRTEEN":
                    return new Thirteen();
                default:
                    throw new Exception("The Type of Game dose not exist");
            }
            
        }
        /// <summary>
        /// Collects all the selected cards anc check if the conditions of the game allows for player to remove the cards
        /// </summary>
        /// <returns>Returns true if cards can be removed</returns>
        public abstract bool ConditionToRemove();
 
        /// <summary>
        /// Adds player to the leaderboard
        /// </summary>
        public void AddToLeadrBoard()
        {
            if (!Leaderboard.TryAdd(PlayerName, 1))
            {
                Leaderboard[PlayerName]++;
            }
        }

        public void PrintHighScore()
        {
            Console.Clear();
            Console.WriteLine("Name Score");
            foreach(var score in Leaderboard)
            {
                Console.WriteLine(score.Key + " " + score.Value);
            }
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// Checks if player is still playing after 10s the player is checked as surrenered
        /// </summary>
        /// <param name="time"></param>
        public void IsStillPlaying(int time)
        {
            HasSurrendered = time < 10;
        }
        /// <summary>
        /// Player can choose to surrrender
        /// </summary>
        public void Forfiet()
        {
            HasSurrendered = true;
        }
        /// <summary>
        /// Changes player name
        /// </summary>
        /// <param name="newName">player new name</param>
        public void ChangeName(string newName)
        {
            PlayerName = newName;
        }
        
    }
}
