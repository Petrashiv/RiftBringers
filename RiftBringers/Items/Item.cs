using RiftBringers.Visual;
using static RiftBringers.Rarity;
namespace RiftBringers.Items
{
    public abstract class Item
    {
        public string Name { get; }
        public string Description { get; }
        public Rarity Rarity { get; }
        public ItemType Type { get; }

        
        public int HealthBonus { get; protected set; }
        public int DamageBonus { get; protected set; }
        public int DefenseBonus { get; protected set; }

        protected Item(string name, string description, Rarity rarity, ItemType type)
        {
            Name = name;
            Description = description;
            Rarity = rarity;
            Type = type;
        }

        public abstract void Use();

        
        public ConsoleColor GetRarityColor()
        {
            return RarityColorHelper.GetColor(Rarity);
        }

        
    }
}