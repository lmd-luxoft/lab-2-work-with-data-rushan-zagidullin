// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using Monopoly.Models;
using NUnit.Framework;
using Type = Monopoly.Models.Type;

namespace Monopoly
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void GetPlayersListReturnCorrectList()
        {
            //Arrange
            string[] players = { "Peter","Ekaterina","Alexander" };
            Player[] expectedPlayers = 
            {
                new Player("Peter",6000),
                new Player("Ekaterina",6000),
                new Player("Alexander",6000)
            };
            Monopoly monopoly = new Monopoly(players);
            //Act
            Player[] actualPlayers = monopoly.GetPlayersList().ToArray();
            //Assert
            Assert.AreEqual(expectedPlayers, actualPlayers);
        }
        [Test]
        public void GetFieldsListReturnCorrectList()
        {
            Field[] expectedCompanies = 
            {
                new Field("Ford",Type.AUTO),
                new Field("MCDonald", Type.FOOD),
                new Field("Lamoda", Type.CLOTHER),
                new Field("Air Baltic",Type.TRAVEL),
                new Field("Nordavia",Type.TRAVEL),
                new Field("Prison",Type.PRISON),
                new Field("MCDonald",Type.FOOD),
                new Field("TESLA",Type.AUTO)
            };
            string[] players = { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Field[] actualCompanies = monopoly.GetFieldsList().ToArray();
            Assert.AreEqual(expectedCompanies, actualCompanies);
        }
        [Test]
        public void PlayerBuyNoOwnedCompanies()
        {
            string[] players = { "Peter", "Ekaterina", "Alexander" };
            int playerIndex = 1;
            Monopoly monopoly = new Monopoly(players);
            Field x = monopoly.GetFieldByName("Ford");
            int expectedBalance = 5500;
            
            monopoly.Buy(playerIndex, x);
            Player player = monopoly.GetPlayerInfo(playerIndex);
            int actualBalance = player.Balance;
            
            Assert.AreEqual(expectedBalance, actualBalance);
            Field actualField = monopoly.GetFieldByName("Ford");
            Assert.AreEqual(player, actualField.Player);
        }
        
        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            string[] players = { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Field  field = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, field);
            field = monopoly.GetFieldByName("Ford");
            monopoly.Renta(2, field);
            Player player1 = monopoly.GetPlayerInfo(1);
            Assert.AreEqual(5750, player1.Balance);
            Player player2 = monopoly.GetPlayerInfo(2);
            Assert.AreEqual(5750, player2.Balance);
        }
    }
}
