using Monopoly.Models;

namespace Monopoly.RentaStrategy
{
    public class RentaFood : IRentaStrategy
    {
        public void Renta(Field field, Player player)
        {
            player.Balance -= 250;
            field.Player.Balance += 250;
        }
    }
}