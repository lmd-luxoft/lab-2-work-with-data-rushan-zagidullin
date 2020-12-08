using Monopoly.Models;

namespace Monopoly.BuyStrategy
{
    public class BuyTravel : IBuyStrategy
    {
        public void Buy(Field field, Player buyer)
        {
            buyer.Balance -= 700;
            field.Player = buyer;
        }
    }
}