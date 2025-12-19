using static RiftBringers.Rarity;
using RiftBringers.Characters;

namespace RiftBringers.Items
{
    public class SteelHelmetOfSpirit : Item
    {
        public SteelHelmetOfSpirit()
            : base(
                name: "Шлем Стального Духа",
                description: "Стальной шлем с древними рунами защиты, которые усиливают жизненную силу владельца",
                rarity: Rarity.Common,
                type: ItemType.Helmet)
        {
            HealthBonus = 30;
            DefenseBonus = 5;
        }

        public override void Use()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.ResetColor();
            Console.WriteLine($"Руны на шлеме загораются синим светом.");
            Console.WriteLine($"Вы чувствуете прилив жизненных сил (+{HealthBonus} HP)!");
            Console.WriteLine($"Защита увеличена на {DefenseBonus}.");
        }
    }
}