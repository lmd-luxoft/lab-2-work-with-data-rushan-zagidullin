using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.BuyStrategy;
using Monopoly.Models;
using Monopoly.RentaStrategy;
using Type = Monopoly.Models.Type;

namespace Monopoly
{
    class Monopoly
    {
        private static readonly int DEFAULT_BALANCE = 6000;  
        private readonly List<Player> _players;
        private List<Field> _fields = new List<Field>();
        
        public Monopoly(string[] players)
        {
            _players = players.Select(name => new Player(name, DEFAULT_BALANCE))
                .ToList();
            _fields.Add(new Field("Ford", Type.AUTO));
            _fields.Add(new Field("MCDonald", Type.FOOD));
            _fields.Add(new Field("Lamoda", Type.CLOTHER));
            _fields.Add(new Field("Air Baltic", Type.TRAVEL));
            _fields.Add(new Field("Nordavia", Type.TRAVEL));
            _fields.Add(new Field("Prison", Type.PRISON));
            _fields.Add(new Field("MCDonald", Type.FOOD));
            _fields.Add(new Field("TESLA", Type.AUTO));
        }

        internal List<Player> GetPlayersList()
        {
            return _players.Select(CopyPlayer).ToList();
        }

        internal List<Field> GetFieldsList()
        {
            return _fields.Select(CopyField).ToList();
        }

        internal Field GetFieldByName(string v)
        {
            return (from p in _fields where p.Name == v select p).FirstOrDefault();
        }

        internal bool Buy(int playerIndex, Field field)
        {
            field = _fields.First(x => x.Name == field.Name);
            var player = GetPlayerInfoInternal(playerIndex);
            StateBuyer stateBuyer = new StateBuyer();
            stateBuyer.Buy(field, player);
            return field.Player != null
                   && field.Player.Equals(player);
        }

        public Player GetPlayerInfo(int playerIndex)
        {
            return CopyPlayer(GetPlayerInfoInternal(playerIndex));
        }

        private Player CopyPlayer(Player player)
        {
            return new Player(player.Name, player.Balance);
        }

        private Field CopyField(Field field)
        {
            Player player = field.Player != null
                ? CopyPlayer(field.Player)
                : null;
            return new Field(field.Name, field.Type, player);
        }

        private Player GetPlayerInfoInternal(int playerIndex)
        {
            return _players[playerIndex - 1];
        }

        internal bool Renta(int playerIndex, Field field)
        {
            field = _fields.First(x => x.Name == field.Name);
            if (field.Player == null)
                return false;
            var player = GetPlayerInfoInternal(playerIndex);
            StateRenta stateRenta = new StateRenta();
            stateRenta.Renta(field, player);
            return true;
        }
    }
}
