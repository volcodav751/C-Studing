using Task6.Models;

namespace Task6.Services;

public static class PlayerFactory
{
    public static Player CreatePlayer()
    {
        return new Player
        {
            Name = "PlayerOne",
            Inventory = new Inventory
            {
                Items = new List<string> { "Sword", "Shield", "Potion" }
            }
        };
    }
}
