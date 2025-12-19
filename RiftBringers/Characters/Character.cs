using System;
using System.Collections.Generic;
using System.Linq;
using RiftBringers.Progression;
using static RiftBringers.Rarity;
namespace RiftBringers.Characters
{
    
    public abstract class Character
    {
        
        private int _currentHealth;
        public bool IsDefending = false;

        public string Name { get; }
        public string Description { get; }

        
        public Rarity Rarity { get; }

        
        public int MaxHealth { get;  set; }
        public int Damage { get;  set; }
        public int Defense { get; set; }

        
        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = Math.Max(0, Math.Min(value, MaxHealth));
        }

        
        public int Level { get; protected set; } = 1;
        public int Experience { get; protected set; }

       
        public Items.Inventory Inventory { get; }

       
        protected readonly List<Skills.Skill> _skills = new();
        public IReadOnlyList<Skills.Skill> Skills => _skills.AsReadOnly();

        protected Character(string name, string description, Rarity rarity,
            int baseHealth, int baseDamage, int baseDefense)
        {
            Name = name;
            Description = description;
            Rarity = rarity;

            
            MaxHealth = PrestigeManager.ApplyPrestige(baseHealth);
            Damage = PrestigeManager.ApplyPrestige(baseDamage);
            Defense = PrestigeManager.ApplyPrestige(baseDefense);

            CurrentHealth = MaxHealth;
            
        }

        
        public int MaxLevel => Rarity switch
        {
            Rarity.Common => 10,
            Rarity.Rare => 20,
            Rarity.Epic => 30,
            Rarity.Legendary => 40,
            _ => 10
        };

        public bool IsAlive => CurrentHealth > 0;

        
        public virtual void Attack(Character target)
        {
            Console.WriteLine($"{Name} атакует {target.Name}.");
            target.TakeDamage(Damage);
        }
        public virtual void Defend()
        {
            Console.WriteLine($"{Name} защищается!");
            Defense *= 2;
        }
        public virtual void UnDefend()
        {
            Defense /= 2;
        }
        public virtual void TakeDamage(int amount)
        {
            int real = Math.Max(1, amount - Defense);
            CurrentHealth -= real;
            Console.WriteLine($"{Name} получает {real} урона. (HP {CurrentHealth}/{MaxHealth})");
        }

        
        public void AddExperience(int amount)
        {
            if (amount <= 0) return;
            Experience += amount;
            Console.WriteLine($"{Name} получает {amount} XP.");

            while (Level < MaxLevel && Experience >= ExpToNextLevel())
            {
                Experience -= ExpToNextLevel();
                LevelUp();
            }
        }

        protected virtual int ExpToNextLevel() => Level * 50;

        protected virtual void LevelUp()
        {
            Level++;
            
            MaxHealth += 10;
            Damage += 3;
            Defense += 1;
            CurrentHealth = MaxHealth;

            Console.WriteLine($"{Name} достиг уровня {Level}!");
            
        }

        
        public IReadOnlyList<Skills.Skill> GetAvailableSkills()
            => _skills.Where(s => s.RequiredLevel <= Level).ToList().AsReadOnly();

        
        public abstract string[] Draw(); 
        public abstract void UseSkill(int skillIndex, Character target); 

        
        public void Heal(int amount)
        {
            if (amount <= 0) return;
            CurrentHealth = Math.Min(MaxHealth, CurrentHealth + amount);
            Console.WriteLine($"{Name} восстанавливает {amount} HP (текущие: {CurrentHealth}/{MaxHealth}).");
        }

        public void ResetHp()
        {
            CurrentHealth = MaxHealth;
        }

        
        protected void AddSkill(Skills.Skill skill)
        {
            if (skill == null) throw new ArgumentNullException(nameof(skill));
            _skills.Add(skill);
        }
    }
}
