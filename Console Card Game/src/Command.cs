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
        public const string SHOWCOMMANDS = "SHOWCOMMANDS";
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
                case SHOWCOMMANDS:
                    ShowCommands();
                    break;
                default:
                    break;

            }
        }
        /// <summary>
        /// prints all commands to the console screen
        /// </summary>
        private static void ShowCommands()
        {
            Console.Clear();
            Console.WriteLine("List of commands");
            Console.WriteLine(SELECT);
            Console.WriteLine(REMOVE);
            Console.WriteLine(REPLACE);
            Console.WriteLine(FORFIET);
            Console.WriteLine(HIGHSCORE);
            Console.WriteLine(CHANGENAME);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        /// <summary>
        /// converts a string input into a token and commands
        /// </summary>
        /// <param name="input"></param>
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
        /// <returns>a list of cards</returns>
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
        /// <summary>
        /// Creates a card from a two charchter string
        /// </summary>
        /// <param name="str_card"></param>
        /// <returns>a card or null if the card could not be created</returns>
        private Card MakeCard(string str_card)
        {
            if (!IsStringAValidCard(str_card)) return null;

            Rank rank = GetRank(str_card[0]);
            Suit suit = GetSuit(str_card[1]);
            return new Card(rank, suit);

        }

        
        /// <summary>
        /// Check is the stirng in the parameter is a valid card
        /// </summary>
        /// <param name="str_card"></param>
        /// <returns>true if card can be created false if an exception was thrown</returns>
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
        /// <summary>
        /// converts the a char into a suit
        /// </summary>
        /// <param name="suit"></param>
        /// <returns>a Suit enum type or an exception</returns>
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
        }/// <summary>
        /// Converts char to a Rank
        /// </summary>
        /// <param name="rank"></param>
        /// <returns>a Rank enum type or throws an exception</returns>
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
