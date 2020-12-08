using Monopoly.Models;

namespace Monopoly.BuyStrategy
{
    public class BuyClother : IBuyStrategy
    {
        public void Buy(Field field, Player buyer)
        {
            buyer.Balance -= 100;
            field.Player = buyer;
        }
    }
}