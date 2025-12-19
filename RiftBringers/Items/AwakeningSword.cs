using static RiftBringers.Rarity;
using RiftBringers.Characters;

namespace RiftBringers.Items
{
    public class AwakeningSword : Item
    {
        public AwakeningSword()
            : base(
                name: "Меч Пробуждения",
                description: "Закаленный клинок, который светится в темноте. Говорят, он пробуждает скрытые силы воина",
                rarity: Rarity.Rare,
                type: ItemType.Weapon)
        {
            DamageBonus = 15;
            HealthBonus = 10; 
        }

        public override void Use()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            
            Console.ResetColor();
            Console.WriteLine($"Клинок начинает светиться мягким голубым светом.");
            Console.WriteLine($"Сила оружия пробуждает внутренние резервы !");
            Console.WriteLine($"Урон увеличен на {DamageBonus}, здоровье на {HealthBonus}.");

            
        }
    }
}