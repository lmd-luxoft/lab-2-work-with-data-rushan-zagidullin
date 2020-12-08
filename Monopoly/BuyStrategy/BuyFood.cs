using Monopoly.Models;

namespace Monopoly.BuyStrategy
{
    public class BuyFood : IBuyStrategy
    {
        public void Buy(Field field, Player buyer)
        {
            buyer.Balance -= 250;
            field.Player = buyer;
        }
    }
}