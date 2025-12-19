using static RiftBringers.Rarity;
using RiftBringers.Characters;

namespace RiftBringers.Items
{
    public class WandererBoots : Item
    {
        public WandererBoots()
            : base(
                name: "Ботинки Странника",
                description: "Прочные кожаные ботинки, испытанные в тысячах путешествий. Даруют выносливость и защиту",
                rarity: Rarity.Common,
                type: ItemType.Boots)
        {
            HealthBonus = 15;
            DefenseBonus = 3;
        }

        public override void Use()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.ResetColor();
            Console.WriteLine($"Ботинки идеально садятся по ноге.");
            Console.WriteLine($"Вы чувствуете, как готов к долгому путешествию!");
            Console.WriteLine($"Выносливость увеличена (+{HealthBonus} HP), защита ног на {DefenseBonus}.");

            
            Console.WriteLine("Эти ботинки уменьшают усталость в долгих походах.");
        }
    }
}