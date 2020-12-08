// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using Monopoly.Models;
using NUnit.Framework;

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
            Tuple<string, Monopoly.Type, int, bool>[] expectedCompanies = 
            {
                new Tuple<string,Monopoly.Type,int,bool>("Ford",Monopoly.Type.AUTO,0,false),
                new Tuple<string,Monopoly.Type,int,bool>("MCDonald", Monopoly.Type.FOOD, 0, false),
                new Tuple<string,Monopoly.Type,int,bool>("Lamoda", Monopoly.Type.CLOTHER, 0, false),
                new Tuple<string, Monopoly.Type, int, bool>("Air Baltic",Monopoly.Type.TRAVEL,0,false),
                new Tuple<string, Monopoly.Type, int, bool>("Nordavia",Monopoly.Type.TRAVEL,0,false),
                new Tuple<string, Monopoly.Type, int, bool>("Prison",Monopoly.Type.PRISON,0,false),
                new Tuple<string, Monopoly.Type, int, bool>("MCDonald",Monopoly.Type.FOOD,0,false),
                new Tuple<string, Monopoly.Type, int, bool>("TESLA",Monopoly.Type.AUTO,0,false)
            };
            string[] players = { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Tuple<string, Monopoly.Type, int, bool>[] actualCompanies = monopoly.GetFieldsList().ToArray();
            Assert.AreEqual(expectedCompanies, actualCompanies);
        }
        [Test]
        public void PlayerBuyNoOwnedCompanies()
        {
            string[] players = { "Peter", "Ekaterina", "Alexander" };
            int playerIndex = 1;
            Monopoly monopoly = new Monopoly(players);
            Tuple<string, Monopoly.Type, int, bool> x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(playerIndex, x);
            Player actualPlayer = monopoly.GetPlayerInfo(playerIndex);
            int actualBalance = actualPlayer.Balance;
            int expectedBalance = 5500;
            
            Assert.AreEqual(expectedBalance, actualBalance);
            Tuple<string, Monopoly.Type, int, bool> actualField = monopoly.GetFieldByName("Ford");
            Assert.AreEqual(playerIndex, actualField.Item3);
        }
        
        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            string[] players = { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Tuple<string, Monopoly.Type, int, bool>  field = monopoly.GetFieldByName("Ford");
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
