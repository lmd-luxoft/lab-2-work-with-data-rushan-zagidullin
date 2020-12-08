using Monopoly.Models;

namespace Monopoly.BuyStrategy
{
    public class BuyAuto : IBuyStrategy
    {
        public void Buy(Field field, Player buyer)
        {
            buyer.Balance -= 500;
            field.Player = buyer;
        }
    }
}