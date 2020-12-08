using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Models;

namespace Monopoly
{
    class Monopoly
    {
        private static readonly int DEFAULT_BALANCE = 6000;  
        private readonly List<Player> _players;
        private List<Tuple<string, Type, int, bool>> _fields = new List<Tuple<string, Type, int, bool>>();
        
        public Monopoly(string[] players)
        {
            _players = players.Select(name => new Player(name, DEFAULT_BALANCE))
                .ToList();
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Ford", Monopoly.Type.AUTO, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("MCDonald", Monopoly.Type.FOOD, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Lamoda", Monopoly.Type.CLOTHER, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Air Baltic", Monopoly.Type.TRAVEL, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Nordavia", Monopoly.Type.TRAVEL, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Prison", Monopoly.Type.PRISON, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("MCDonald", Monopoly.Type.FOOD, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("TESLA", Monopoly.Type.AUTO, 0, false));
        }

        internal List<Player> GetPlayersList()
        {
            return _players.Select(CopyPlayer).ToList();
        }

        internal enum Type
        {
            AUTO,
            FOOD,
            CLOTHER,
            TRAVEL,
            PRISON,
            BANK
        }

        internal List<Tuple<string, Monopoly.Type, int, bool>> GetFieldsList()
        {
            return _fields;
        }

        internal Tuple<string, Type, int, bool> GetFieldByName(string v)
        {
            return (from p in _fields where p.Item1 == v select p).FirstOrDefault();
        }

        internal bool Buy(int playerIndex, Tuple<string, Type, int, bool> field)
        {
            var x = GetPlayerInfoInternal(playerIndex);
            int cash = 0;
            switch(field.Item2)
            {
                case Type.AUTO:
                    if (field.Item3 != 0)
                        return false;
                    cash = x.Balance - 500;
                    _players[playerIndex - 1] = new Player(x.Name, cash);
                    break;
                case Type.FOOD:
                    if (field.Item3 != 0)
                        return false;
                    cash = x.Balance - 250;
                    _players[playerIndex - 1] = new Player(x.Name, cash);
                    break;
                case Type.TRAVEL:
                    if (field.Item3 != 0)
                        return false;
                    cash = x.Balance - 700;
                    _players[playerIndex - 1] = new Player(x.Name, cash);
                    break;
                case Type.CLOTHER:
                    if (field.Item3 != 0)
                        return false;
                    cash = x.Balance - 100;
                    _players[playerIndex - 1] = new Player(x.Name, cash);
                    break;
                default:
                    return false;
            }
            int i = _players.Select((item, index) => new { name = item.Name, index = index })
                .Where(n => n.name == x.Name)
                .Select(p => p.index).FirstOrDefault();
            _fields[i] = new Tuple<string, Type, int, bool>(field.Item1, field.Item2, playerIndex, field.Item4);
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

        private Player GetPlayerInfoInternal(int playerIndex)
        {
            return _players[playerIndex - 1];
        }

        internal bool Renta(int playerIndex, Tuple<string, Type, int, bool> k)
        {
            Player player = GetPlayerInfoInternal(playerIndex);
            Player fieldOwner;
            switch(k.Item2)
            {
                case Type.AUTO:
                    if (k.Item3 == 0)
                        return false;
                    fieldOwner =  GetPlayerInfoInternal(k.Item3);
                    player.Balance -= 250;
                    fieldOwner.Balance += 250;
                    break;
                case Type.FOOD:
                    if (k.Item3 == 0)
                        return false;
                    fieldOwner = GetPlayerInfoInternal(k.Item3);
                    player.Balance -= 250;
                    fieldOwner.Balance += 250;

                    break;
                case Type.TRAVEL:
                    if (k.Item3 == 0)
                        return false;
                    fieldOwner = GetPlayerInfoInternal(k.Item3);
                    player.Balance -= 300;
                    fieldOwner.Balance += 300;
                    break;
                case Type.CLOTHER:
                    if (k.Item3 == 0)
                        return false;
                    fieldOwner = GetPlayerInfoInternal(k.Item3);
                    player.Balance -= 100;
                    fieldOwner.Balance += 100;

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
