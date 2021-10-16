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

        private Dictionary<string, int> leaderboard;
        public string PlayerName { get; private set; }
        /// <summary>
        /// Gets the boolean value if the player has surrenered 
        /// </summary>
        public bool HasSurrendered { get; private set; }
        /// <summary>
        /// gets the type of game
        /// </summary>
        public abstract int GameType { get; }
        protected Game(int sizeOfBoard) : base(sizeOfBoard) { }

        protected abstract bool CheckConditions();
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
        public bool ConditionToRemove()
        {
            SelectedCardsOnBoard = CardsOnBoard.FindAll(card => card.Selected == true);
            return CheckConditions();
        }
        /// <summary>
        /// Adds player to the leaderboard
        /// </summary>
        public void addToLeadrBoard()
        {
            if (!leaderboard.TryAdd(PlayerName, 1))
            {
                leaderboard[PlayerName]++;
            }
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
