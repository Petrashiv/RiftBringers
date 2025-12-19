using static RiftBringers.Rarity;
using RiftBringers.Characters;

namespace RiftBringers.Items
{
    public class ShadowPants : Item
    {
        public ShadowPants()
            : base(
                name: "Штаны Тени",
                description: "Легкие и бесшумные штаны, пропитанные энергией сумрака.",
                rarity: Rarity.Rare,
                type: ItemType.Pants)
        {
            HealthBonus = 12;
            DefenseBonus = 8;
        }

        public override void Use()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            
            Console.ResetColor();
            Console.WriteLine("Ткань словно растворяется в движении.");
            Console.WriteLine($"Вы становитесь быстрее и выносливее.");
            Console.WriteLine($"Здоровье увеличено на {HealthBonus}, Защита на {DefenseBonus}.");

            
        }
    }
}
