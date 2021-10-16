namespace CardGame
{
    /// <summary>
    /// Thirteens uses a 10-card board. Ace, 2, …, 10, jack, queen correspond to the point 
    /// values of 1, 2, …, 10, 11, 12. Pairs of cards whose point values add up to 13 are
    /// selected and removed. Kings are selected and removed singly. 
    /// Chances of winning are claimed to be about 1 out of 2.
    /// </summary>
    class Thirteen : Game
    {
        /// <summary>
        ///Constructor sends the size of board is 10
        /// </summary>
        public Thirteen() : base(10) { }
        public override int GameType { get { return TEN; } }
        /// <summary>
        /// Thirteen game conditon to remove cards from board
        /// </summary>
        /// <returns>True if either one kind is selected or cards add up to thirteen</returns>
        protected override bool CheckConditions()
        {

            if (SelectedCardsOnBoard.Count == 1)
            {
                return IsSingleKing();
            }

            return CardAddUp(THIRTEEN);
        }
        /// <summary>
        /// Checks if the only card selected is a king
        /// </summary>
        /// <returns>Returns true if the only card in the list is a king otherwise, false</returns>
        private bool IsSingleKing()
        {
            return SelectedCardsOnBoard[0].Rank == Rank.King;
        }
    }

}
