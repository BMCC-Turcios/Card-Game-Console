using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    /// <summary>
    /// Command class that contains a list of commands for user
    /// </summary>
    public class Command
    {
        public const string SELECT = "SELECT";
        public const string REMOVE = "REMOVE";
        public const string REPLACE = "REPLACE";
        public const string FORFIET = "FORFIET";
        public const string HIGHSCORE = "HIGHSCORE";
        public const string CHANGENAME = "CHANGENAME";
        private string Token { get; set; }
        private string[] CommandLine { get; set; }

        /// <summary>
        /// Excutes the command issued by the player
        /// </summary>
        /// <param name="command">A array that contains the players input</param>
        /// <param name="gameObj">The current game</param>
        public void ExecuteCommand(Game gameObj)
        {
            switch (Token)
            {
                case SELECT:
                    List<Card> CommandCards = MakeListOfCards(CommandLine);
                    gameObj.SelectCard(CommandCards);
                    break;
                case REMOVE:
                    if (gameObj.ConditionToRemove())
                    {
                        gameObj.Remove();
                    }
                    break;
                case REPLACE:
                    gameObj.Replace();
                    break;
                case FORFIET:
                    gameObj.Forfiet();
                    break;
                case HIGHSCORE:
                    gameObj.PrintHighScore();
                    break;
                case CHANGENAME:
                    gameObj.ChangeName(CommandLine[0]);
                    break;

                default:
                    break;

            }
        }
        public void GetCommand(string input)
        {
            CommandLine = input.Split(' ');
            Token = CommandLine[0];
            CommandLine = CommandLine.Skip(1).ToArray();
        }
        /// <summary>
        /// creates a list of cards the player wishes to send to game object
        /// </summary>
        /// <param name="array_cards"></param>
        /// <returns></returns>
        private List<Card> MakeListOfCards(string[] array_cards)
        {
            List<Card> listOfCard = new List<Card>();
            Card card;
            foreach (string str_card in array_cards)
            {
                card = MakeCard(str_card);

                if (card != null)
                    listOfCard.Add(card);
            }

            return listOfCard;
        }

        private Card MakeCard(string str_card)
        {
            if (!IsStringAValidCard(str_card)) return null;

            Rank rank = GetRank(str_card[0]);
            Suit suit = GetSuit(str_card[1]);
            return new Card(rank, suit);

        }

        

        private bool IsStringAValidCard(string str_card)
        {
            if (str_card.Length != 2) return false; //guard clause

            bool hasNotThrownException = true;
            try
            {
                GetRank(str_card[0]);
                GetSuit(str_card[1]);
            }
            catch
            {
                hasNotThrownException = false;
            }

            return hasNotThrownException;
        }

        private Suit GetSuit(char suit)
        {
            switch (suit)
            {
                case 'D':
                    return Suit.Diamonds;
                case 'H':
                    return Suit.Hearts;
                case 'C':
                    return Suit.Clubs;
                case 'S':
                    return Suit.Spade;
            }
            throw new Exception();
        }
        private Rank GetRank(char rank)
        {
            switch (rank)
            {
                case 'A':
                    return Rank.Ace;
                case '2':
                    return Rank.Two;
                case '3':
                    return Rank.Three;
                case '4':
                    return Rank.Four;
                case '5':
                    return Rank.Five;
                case '6':
                    return Rank.Six;
                case '7':
                    return Rank.Seven;
                case '8':
                    return Rank.Eight;
                case '9':
                    return Rank.Nine;
                case 'T':
                    return Rank.Ten;
                case 'J':
                    return Rank.Jack;
                case 'Q':
                    return Rank.Queen;
                case 'K':
                    return Rank.King;
            }
            throw new Exception();
        }
    }



}
