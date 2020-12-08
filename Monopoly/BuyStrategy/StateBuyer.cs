using System.Collections.Generic;
using Monopoly.Models;

namespace Monopoly.BuyStrategy
{
    public class StateBuyer : IBuyStrategy
    {
        private Dictionary<Type, IBuyStrategy> strategies = new Dictionary<Type, IBuyStrategy>
        {
            {Type.AUTO, new BuyAuto()},
            {Type.FOOD, new BuyFood()},
            {Type.CLOTHER, new BuyClother()},
            {Type.TRAVEL, new BuyTravel()},
            {Type.PRISON, new BuyPrison()},
            {Type.BANK, new BuyBank()},
        };
        
        public void Buy(Field field, Player buyer)
        {
            strategies[field.Type].Buy(field, buyer);
        }
    }
}