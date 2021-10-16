

using CardGame;
using System.Collections.Generic;
using Xunit;

namespace GameUnitTest
{
    public class Mock_Board_Class : Board
    {
        public const int MockSize = 52;
        public Mock_Board_Class() : base(MockSize)
        {
        }

        public int Total_Cards_On_Board { get { return CardsOnBoard.Count; } }
        public List<Card> MockCardsOnBoard { get { return CardsOnBoard; } set { MockCardsOnBoard = value; } }
    }
    public class Board_Test
    {


        [Fact]
        public void Reset_Test()
        {
            var board = new Mock_Board_Class();

            board.Reset();
            int TotalCardsOnBoard = board.Total_Cards_On_Board;


            Assert.Equal(Mock_Board_Class.MockSize, TotalCardsOnBoard);
        }
        [Fact]
        public void Remove_Test()
        {






        }
        [Fact]
        public void Replace_Test()
        {

        }
        [Fact]
        public void SelectCard_Test()
        {

        }
        [Fact]
        public void Has_Won_Test()
        {

        }

    }
}
