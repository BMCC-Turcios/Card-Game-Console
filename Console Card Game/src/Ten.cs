namespace CardGame
{
    /// <summary>
    /// Tens uses a 13-card board.
    /// Pairs of cards whose point values add to 10 
    /// are selected and removed, as are quartets of 
    /// kings, queens, jacks, and tens, all of the same rank.
    /// </summary>
    class Ten : Game
    {
        /// <summary>
        /// Constructor that sends the base class Game the size of board
        /// </summary>
        public Ten() : base(THIRTEEN) { }
        /// <summary>
        /// Gets the current game type set to return Game.TEN
        /// </summary>
        public override int GameType { get { return TEN; } }
        /// <summary>
        /// Ten game conditon to remove cards from board
        /// </summary>
        /// <returns>Return true if selected card are four of the same rank,is a King, Queen, Jack, Ten, or if two cards add up to Ten</returns>
        public override bool ConditionToRemove()
        {
            if (SelectedCardsOnBoard.Count == 4)
            {
                return IsFourSameRank() | CheckKQJT();
            }

            return CardAddUp(TEN);

        }
        /// <summary>
        /// Check if all cards are King, Queen, Jack, Ten
        /// </summary>
        /// <returns>return true if cards selected are all King, Queen, Jack, Ten</returns>
        private bool CheckKQJT()
        {
            return SelectedCardsOnBoard.TrueForAll(card => MatchKQJT(card));
        }
        private bool MatchKQJT(Card card)
        {
            return card.Rank == Rank.King || card.Rank == Rank.Queen || card.Rank == Rank.Jack || card.Rank == Rank.Ten;
        }
        /// <summary>
        /// Check if all cards are of the same Rank
        /// </summary>
        /// <returns>Return true if all cards are of the same Rank</returns>
        private bool IsFourSameRank()
        {
            return SelectedCardsOnBoard.TrueForAll(card => card.Rank == SelectedCardsOnBoard[0].Rank);
        }
    }
}
