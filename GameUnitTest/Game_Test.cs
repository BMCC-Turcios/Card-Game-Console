using CardGame;
using System;
using Xunit;

namespace GameUnitTest
{
    public class Game_Test
    {
        [Fact]
        public void Is_GameType_A_Ten_Game()
        {
            Game game = Game.Create("TEN");

            Assert.Equal(Game.TEN, game.GameType);
        }
        [Fact]
        public void IsGameTypeAElevenGame()
        {
            Game game = Game.Create("ELEVEN");

            Assert.Equal(Game.ELEVEN, game.GameType);
        }
        [Fact]
        public void IsGameTypeAThirteenGame()
        {
            Game game = Game.Create("THIRTEEN");

            Assert.Equal(Game.THIRTEEN, game.GameType);
        }

        [Fact]
        public void PlayerForfietTenTest()
        {
            Game game = Game.Create("TEN");

            game.Forfiet();

            Assert.True(game.HasSurrendered);
        }
        [Fact]
        public void PlayerForfietElevenTest()
        {
            Game game = Game.Create("ELEVEN");

            game.Forfiet();

            Assert.True(game.HasSurrendered);
        }
        [Fact]
        public void PlayerForfietThirteenTest()
        {
            Game game = Game.Create("THIRTEEN");

            game.Forfiet();

            Assert.True(game.HasSurrendered);
        }
    }
}
