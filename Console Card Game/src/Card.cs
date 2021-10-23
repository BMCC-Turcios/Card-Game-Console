using System;

namespace CardGame
{
    
    /// <summary>
    /// Enums that represent ran
    /// </summary>
    public enum Rank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
    /// <summary>
    /// Enums that represents suits
    /// </summary>
    public enum Suit
    {
        Diamonds = '♦',
        Hearts = '♥',
        Clubs = '♣',
        Spade = '♠'
    }

    /// <summary>
    /// A class that represents a playing card
    /// </summary>
    public class Card : IEquatable<Card>
    {

        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }
        public bool Selected { get; private set; }
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
            Selected = false;

        }
        /// <summary>
        /// Selects this card
        /// </summary>
        public void SelectCard()
        {
            Selected = !Selected;
        }
        /// <summary>
        /// Returns two string of the card
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            return RankToString() + ((char)Suit).ToString();
        }

        private string RankToString()
        {
            
            if (Rank != Rank.Ace && Rank != Rank.King && Rank != Rank.Queen && Rank != Rank.Jack && Rank != Rank.Ten)
                return ((int)Rank + 1).ToString();
            return Rank.ToString()[0].ToString();

        }
        /// <summary>
        /// checks if both cards are equal
        /// </summary>
        /// <param name="other">Other card</param>
        /// <returns>true if rank and suit are equal to each other</returns>
        public bool Equals(Card other)
        {
            return this.Rank == other.Rank && this.Suit == other.Suit;
        }
    }
}
