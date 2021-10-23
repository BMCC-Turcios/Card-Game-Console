using System;
using System.Collections.Generic;

namespace CardGame
{
    /// <summary>
    /// Creates a abstract board that reprsents a board of cards
    /// </summary>
    abstract public class Board
    {
        private Deck deck;
        protected List<Card> CardsOnBoard { get; private set; }
        protected List<Card> SelectedCardsOnBoard { get; set; }
        protected int MaxCard { get; private set; }

        protected Board(int sizeOfBoard)
        {
            SelectedCardsOnBoard = new List<Card>();
            CardsOnBoard = new List<Card>();
            MaxCard = sizeOfBoard;
            Reset();
        }
        /// <summary>
        /// Resets the board
        /// </summary>
        public void Reset()
        {
            deck = new Deck();
            deck.Shuffle();
            CardsOnBoard.Clear();
            for (int i = 0; i < MaxCard; i++)
            {
                CardsOnBoard.Add(deck.TakeTopCard());
            }
        }
        /// <summary>
        /// Removes all cards that are selected
        /// </summary>
        public void Remove()
        {
            CardsOnBoard.RemoveAll(card => card.Selected == true);
            SelectedCardsOnBoard.Clear();
        }
        /// <summary>
        /// Replace cards on the board till it shows the maximum cards that should be on the board
        /// </summary>
        public void Replace()
        {
            if (deck.Count != 0)
            {
                int CardsToAdd = MaxCard - CardsOnBoard.Count;
                Card topcard;
                for (int i = 0; i < CardsToAdd; i++)
                {
                    topcard = deck.TakeTopCard();
                    if (topcard == null) return;
                        CardsOnBoard.Add(topcard);

                    
                }
            }
        }
        /// <summary>
        /// Cards that are on the board that match the list 'cardsToBeSelected' will be selected
        /// </summary>
        /// <param name="cardsToBeSelected">Card that the user wishes to select</param>
        public void SelectCard(List<Card> cardsToBeSelected)
        {
            int selectedCardIndex;
            foreach (Card card in cardsToBeSelected)
            {
                selectedCardIndex = CardsOnBoard.IndexOf(card);
                if (selectedCardIndex != -1)
                {
                    CardsOnBoard[selectedCardIndex].SelectCard();
                }
                else
                {
                    Console.WriteLine(card.ToString() + "Could not be found");
                }
                SelectedCardsOnBoard = CardsOnBoard.FindAll(card => card.Selected == true);
            }
        }
        protected bool CardAddUp(int sumOfCards)
        {
            if (SelectedCardsOnBoard.Count == 2)
            {
                return (int)SelectedCardsOnBoard[0].Rank + (int)SelectedCardsOnBoard[1].Rank + 2 == sumOfCards;
            }

            return false;
        }
        /// <summary>
        /// Checks if user has won the game
        /// </summary>
        /// <returns>True if the deck is empty and there are no cards on the board</returns>
        public bool HasWon()
        {
            return deck.IsEmpty && CardsOnBoard.Count == 0;
        }
        /// <summary>
        /// Prints to the console all cards on the board and remaining cards in the deck.
        /// </summary>
        public void printBoard()
        {
            string board = "";
            foreach(Card card in CardsOnBoard)
            {
                board += card.ToString() + " ";
            }
            Console.WriteLine(board + "\nCards left in deck: " + deck.Count);
            if(SelectedCardsOnBoard.Count != 0)
            {
                board = "";
                foreach(Card card in SelectedCardsOnBoard)
                {
                    board += card.ToString() + " ";
                }
                Console.WriteLine("Cards selected\n" + board);
            }

        }
    }   
}
