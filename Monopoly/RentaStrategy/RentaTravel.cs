using Monopoly.Models;

namespace Monopoly.RentaStrategy
{
    public class RentaTravel : IRentaStrategy
    {
        public void Renta(Field field, Player player)
        {
            player.Balance -= 300;
            field.Player.Balance += 300;
        }
    }
}