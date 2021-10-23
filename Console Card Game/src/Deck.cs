using System;
using System.Collections.Generic;

namespace CardGame
{
    /// <summary>
    /// A class that represents a deck of playing cards
    /// </summary>
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        /// <summary>
        /// Returns true or false if deck is empty
        /// </summary>
        public bool IsEmpty { get { return cards.Count == 0; } }
        /// <summary>
        /// Shuffle the deck
        /// </summary>
        public void Shuffle()
        {
            Random rand = new Random();
            Card copyOfCard;
            int randomIndex;
            for (int i = cards.Count - 1; i > 0; i--)
            {
                randomIndex = rand.Next(i);
                copyOfCard = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = copyOfCard;

            }
        }
        /// <summary>
        /// Create a new deck
        /// </summary>
        public Deck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }
        /// <summary>
        /// Takes the top card of the deck and removes it from the list
        /// </summary>
        /// <returns>Returns a Card object of the top card</returns>
        public Card TakeTopCard()
        {
            Card topCard = null;
            if (cards.Count != 0)
            {
                topCard = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
            }
                return topCard;
        }
        /// <summary>
        /// Gets the count of the remaining cards in the deck.
        /// </summary>
        public int Count
        {
            get { return cards.Count; }
        }

    }
}
