using static RiftBringers.Rarity;
using RiftBringers.Characters;

namespace RiftBringers.Items
{
    public class TitanChestplate : Item
    {
        public TitanChestplate()
            : base(
                name: "Нагрудник Титана",
                description: "Тяжелая броня, выкованная из древнего сплава. Говорят, она выдерживала удары богов.",
                rarity: Rarity.Epic,
                type: ItemType.Chestplate)
        {
            HealthBonus = 40;
            DefenseBonus = 15;
        }

        public override void Use()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            
            Console.ResetColor();
            Console.WriteLine("Металл с глухим звоном встает на место.");
            Console.WriteLine($"Тело  наполняется невероятной стойкостью.");
            Console.WriteLine($"Здоровье увеличено на {HealthBonus}, защита на {DefenseBonus}.");

            
        }
    }
}
