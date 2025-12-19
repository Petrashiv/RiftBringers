using static RiftBringers.Rarity;
using RiftBringers.Characters;

namespace RiftBringers.Items
{
    public class EternalAmulet : Item
    {
        public EternalAmulet()
            : base(
                name: "Амулет Жесткий",
                description: "Древний артефакт, непрерывно источающий магическую энергию.",
                rarity: Rarity.Legendary,
                type: ItemType.Amulet)
        {
            DamageBonus = 50;
            
        }

        public override void Use()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.ResetColor();
            Console.WriteLine("Амулет вспыхивает золотым светом.");
            Console.WriteLine("Потоки маны наполняют тело владельца.");
            Console.WriteLine($"Урон увеличен на {DamageBonus}");

            
        }
    }
}
