using Monopoly.Models;

namespace Monopoly.RentaStrategy
{
    public class RentaClother : IRentaStrategy
    {
        public void Renta(Field field, Player player)
        {
            player.Balance -= 100;
            field.Player.Balance += 100;
        }
    }
}