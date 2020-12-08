using Monopoly.Models;

namespace Monopoly.RentaStrategy
{
    public class RentaPrison : IRentaStrategy
    {
        public void Renta(Field field, Player player)
        {
            player.Balance -= 1000;
        }
    }
}