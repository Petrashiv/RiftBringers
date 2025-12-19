using System;
using RiftBringers.Characters;

namespace RiftBringers.Visual
{
    public static class RarityColorHelper
    {
        public static ConsoleColor GetColor(Rarity rarity)
        {
            return rarity switch
            {
                Rarity.Common => ConsoleColor.Gray,
                Rarity.Rare => ConsoleColor.Blue,
                Rarity.Epic => ConsoleColor.Magenta,
                Rarity.Legendary => ConsoleColor.Yellow,
                _ => ConsoleColor.White
            };
        }
        
    }
}
