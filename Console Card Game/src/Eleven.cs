namespace CardGame
{
    /// <summary>
    /// Eleven uses a 11-card board.
    /// Pairs of cards whose point values add to 11 
    /// are selected and removed, as are face card of 
    /// kings, queens, and jacks.
    /// </summary>
    class Eleven : Game
    {
        /// <summary>
        /// Constructor that sends the base class game the sizeOfBoard
        /// </summary>
        public Eleven() : base(ELEVEN) { }
        /// <summary>
        /// Gets the game type set to Game.ELEVEN
        /// </summary>
        public override int GameType { get { return ELEVEN; } }
        /// <summary>
        /// Check if conditions to remove are three cards that are King, Queen, Jack, or Cards that add up to 11.
        /// </summary>
        /// <returns></returns>
        protected override bool CheckConditions()
        {
            if (SelectedCardsOnBoard.Count == 3)
            {
                return SelectedCardsOnBoard.TrueForAll(card => MatchKQJ(card)); ;
            }

            return CardAddUp(ELEVEN);
        }

        private bool MatchKQJ(Card card)
        {
            return card.Rank == Rank.King || card.Rank == Rank.Queen || card.Rank == Rank.Jack;
        }

    }

}
