using Monopoly.Models;

namespace Monopoly.RentaStrategy
{
    public class RentaBank : IRentaStrategy
    {
        public void Renta(Field field, Player player)
        {
            player.Balance -= 700;
        }
    }
}