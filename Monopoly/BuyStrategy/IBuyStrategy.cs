using Monopoly.Models;

namespace Monopoly.BuyStrategy
{
    public interface IBuyStrategy
    {
        void Buy(Field field, Player buyer);
    }
}