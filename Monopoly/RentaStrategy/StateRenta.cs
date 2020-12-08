using System.Collections.Generic;
using Monopoly.Models;

namespace Monopoly.RentaStrategy
{
    public class StateRenta : IRentaStrategy
    {
        private Dictionary<Type, IRentaStrategy> strategies = new Dictionary<Type, IRentaStrategy>
        {
            {Type.AUTO, new RentaAuto()},
            {Type.FOOD, new RentaFood()},
            {Type.CLOTHER, new RentaClother()},
            {Type.TRAVEL, new RentaTravel()},
            {Type.PRISON, new RentaPrison()},
            {Type.BANK, new RentaBank()},
        };
        
        public void Renta(Field field, Player player)
        {
            strategies[field.Type].Renta(field, player);
        }
    }
}