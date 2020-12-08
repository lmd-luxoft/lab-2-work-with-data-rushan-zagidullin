using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Models;
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
            var player = GetPlayerInfoInternal(playerIndex);
            switch(field.Type)
            {
                case Type.AUTO:
                    if (field.Player != null)
                        return false;
                    player.Balance -= 500;
                    break;
                case Type.FOOD:
                    if (field.Player != null)
                        return false;
                    player.Balance -= 250;
                    break;
                case Type.TRAVEL:
                    if (field.Player != null)
                        return false;
                    player.Balance -= 700;
                    break;
                case Type.CLOTHER:
                    if (field.Player != null)
                        return false;
                    player.Balance -= 100;
                    break;
                default:
                    return false;
            }
            int i = _fields.Select((item, index) => new { name = item.Name, index = index })
                .Where(n => n.name == player.Name)
                .Select(p => p.index).FirstOrDefault();
            _fields[i].Player = player;
             return true;
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

        internal bool Renta(int playerIndex, Field k)
        {
            Player player = GetPlayerInfoInternal(playerIndex);
            switch(k.Type)
            {
                case Type.AUTO:
                    if (k.Player == null)
                        return false;
                    player.Balance -= 250;
                    k.Player.Balance += 250;
                    break;
                case Type.FOOD:
                    if (k.Player == null)
                        return false;
                    player.Balance -= 250;
                    k.Player.Balance += 250;

                    break;
                case Type.TRAVEL:
                    if (k.Player == null)
                        return false;
                    player.Balance -= 300;
                    k.Player.Balance += 300;
                    break;
                case Type.CLOTHER:
                    if (k.Player == null)
                        return false;
                    player.Balance -= 100;
                    k.Player.Balance += 100;

                    break;
                case Type.PRISON:
                    player.Balance -= 1000;
                    break;
                case Type.BANK:
                    player.Balance -= 700;
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}
