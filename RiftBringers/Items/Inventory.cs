using System;
using System.Collections.Generic;
using System.Linq;

namespace RiftBringers.Items
{
    public class Inventory
    {
        
        private readonly Dictionary<ItemType, Item> _equipment = new Dictionary<ItemType, Item>
        {
            { ItemType.Helmet, null },
            { ItemType.Chestplate, null },
            { ItemType.Pants, null },
            { ItemType.Boots, null },
            { ItemType.Weapon, null },
            { ItemType.Amulet, null }
        };

        
        public bool EquipItem(Item item)
        {
            if (item == null) return false;

            Item currentItem = _equipment[item.Type];

            
            if (currentItem != null)
            {
                Console.WriteLine($"Снимаем {currentItem.Name}...");
            }

            
            _equipment[item.Type] = item;

            Console.ForegroundColor = item.GetRarityColor();
            Console.WriteLine($" {item.Name} экипирован!");
            Console.ResetColor();

            return true;
        }

       
        public bool UnequipItem(ItemType itemType)
        {
            Item item = _equipment[itemType];
            if (item == null) return false;

            _equipment[itemType] = null;
            Console.WriteLine($" {item.Name} снят");
            return true;
        }

        
        public Item GetItem(ItemType itemType)
        {
            return _equipment[itemType];
        }

        
        public bool IsSlotOccupied(ItemType itemType)
        {
            return _equipment[itemType] != null;
        }

        
        public IEnumerable<Item> GetAllItems()
        {
            foreach (var item in _equipment.Values)
            {
                if (item != null) yield return item;
            }
        }

        
        public EquipmentStats GetTotalStats()
        {
            var stats = new EquipmentStats();

            foreach (var item in GetAllItems())
            {
                stats.HealthBonus += item.HealthBonus;
                stats.DamageBonus += item.DamageBonus;
                stats.DefenseBonus += item.DefenseBonus;
            }

            return stats;
        }

        
        public void ApplyBonusesToTeam(List<Characters.Character> team)
        {
            var stats = GetTotalStats();

            foreach (var character in team)
            {
                if (character != null)
                {
                    
                    character.MaxHealth += stats.HealthBonus;
                    character.Damage += stats.DamageBonus;
                    character.Defense += stats.DefenseBonus;

                    
                    if (stats.HealthBonus > 0)
                    {
                        character.Heal(stats.HealthBonus);
                    }
                }
            }
        }

        
        public void RemoveBonusesFromTeam(List<Characters.Character> team)
        {
            var stats = GetTotalStats();

            foreach (var character in team)
            {
                if (character != null)
                {
                    character.MaxHealth -= stats.HealthBonus;
                    character.Damage -= stats.DamageBonus;
                    character.Defense -= stats.DefenseBonus;

                    
                    if (character.CurrentHealth > character.MaxHealth)
                    {
                        character.CurrentHealth = character.MaxHealth;
                    }
                }
            }
        }

        
        public void DisplayEquipment()
        {
            Console.WriteLine("\n ЭКИПИРОВКА ");

            foreach (var kvp in _equipment)
            {
                Console.Write($"{GetItemTypeName(kvp.Key)}: ");

                if (kvp.Value != null)
                {
                    Console.ForegroundColor = kvp.Value.GetRarityColor();
                    Console.WriteLine($" {kvp.Value.Name}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("[Пусто]");
                }
            }

            
            DisplayTotalBonuses();
        }

        
        public void DisplayTotalBonuses()
        {
            var stats = GetTotalStats();

            Console.WriteLine("\n БОНУСЫ КОМАНДЫ ");
            Console.WriteLine($"  Здоровье: +{stats.HealthBonus} ");
            Console.WriteLine($"  Урон: +{stats.DamageBonus} ");
            Console.WriteLine($"  Защита: +{stats.DefenseBonus} ");
        }


       

        
        public void DisplayEquipmentVisual()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ЭКИПИРОВКА КОМАНДЫ ");
            Console.ResetColor();

            Console.WriteLine();

            
            Console.Write("        ");
            DisplayColoredSymbol(ItemType.Helmet);
            Console.WriteLine("        ");

            
            Console.Write("        ");
            DisplayColoredSymbol(ItemType.Amulet);
            Console.WriteLine("        ");

            
            Console.WriteLine($"       /|\\       ");
            Console.WriteLine($"      / | \\      ");

            
            Console.Write("    ");
            DisplayColoredSymbol(ItemType.Weapon);
            Console.Write("   |  ");
            DisplayColoredSymbol(ItemType.Chestplate);
            Console.WriteLine();

            
            Console.WriteLine($"       / \\       ");
            Console.WriteLine($"      /   \\      ");

            
            Console.Write("     ");
            DisplayColoredSymbol(ItemType.Pants);
            Console.Write("   ");
            DisplayColoredSymbol(ItemType.Boots);
            Console.WriteLine();
            Console.WriteLine();

            
            DisplayEquipment();
        }

        
        private void DisplayColoredSymbol(ItemType itemType)
        {
            Item item = _equipment[itemType];

            if (item == null)
            {
                Console.Write(" "); 
            }
            else
            {
                Console.ForegroundColor = item.GetRarityColor();
                Console.Write("*");
                Console.ResetColor();
            }
        }

        private string GetItemTypeName(ItemType itemType)
        {
            return itemType switch
            {
                ItemType.Helmet => " Шлем",
                ItemType.Chestplate => " Нагрудник",
                ItemType.Pants => " Штаны",
                ItemType.Boots => " Сапоги",
                ItemType.Weapon => " Оружие",
                ItemType.Amulet => " Амулет",
                _ => " Неизвестно"
            };
        }

        
        public void ClearEquipment()
        {
            foreach (var itemType in _equipment.Keys)
            {
                _equipment[itemType] = null;
            }
            Console.WriteLine("Вся экипировка снята");
        }
    }

    
    public class EquipmentStats
    {
        public int HealthBonus { get; set; }
        public int DamageBonus { get; set; }
        public int DefenseBonus { get; set; }
    }
}