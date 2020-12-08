using Monopoly.Models;

namespace Monopoly.RentaStrategy
{
    public interface IRentaStrategy
    {
        void Renta(Field field, Player player);
    }
}