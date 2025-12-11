using System;
using System.Collections.Generic;
using System.Linq;
using RiftBringers.Progression;

namespace RiftBringers.Characters
{
    public enum Rarity
    {
        Common,     // Макс. уровень 10
        Rare,       // Макс. уровень 20
        Epic,       // Макс. уровень 30
        Legendary   // Макс. уровень 40
    }
    public abstract class Character
    {
        // Основные (базовые) поля — приватные, доступ извне через свойства
        private int _currentHealth;

        // Метаданные
        public string Name { get; }
        public string Description { get; }

        // Редкость (определяет max level)
        public Rarity Rarity { get; }

        // Базовые характеристики, уже с учётом престижа в конструкторе
        public int MaxHealth { get; protected set; }
        public int Damage { get; protected set; }
        public int Defense { get; protected set; }

        // Текущее здоровье
        public int CurrentHealth
        {
            get => _currentHealth;
            protected set => _currentHealth = Math.Max(0, Math.Min(value, MaxHealth));
        }

        // Прогресс
        public int Level { get; protected set; } = 1;
        public int Experience { get; protected set; }

        // Инвентарь — публично читаем, внутренняя реализация скрыта
        public Items.Inventory Inventory { get; }

        // Список всех умений персонажа
        protected readonly List<Skills.Skill> _skills = new();
        public IReadOnlyList<Skills.Skill> Skills => _skills.AsReadOnly();

        protected Character(string name, string description, Rarity rarity,
            int baseHealth, int baseDamage, int baseDefense)
        {
            Name = name;
            Description = description;
            Rarity = rarity;

            // Применяем престиж при установке базовых значений
            MaxHealth = PrestigeManager.ApplyPrestige(baseHealth);
            Damage = PrestigeManager.ApplyPrestige(baseDamage);
            Defense = PrestigeManager.ApplyPrestige(baseDefense);

            CurrentHealth = MaxHealth;
            Inventory = new Items.Inventory(6); // 6 слотов по ТЗ
        }

        // Ограничение максимального уровня по редкости
        public int MaxLevel => Rarity switch
        {
            Rarity.Common => 10,
            Rarity.Rare => 20,
            Rarity.Epic => 30,
            Rarity.Legendary => 40,
            _ => 10
        };

        public bool IsAlive => CurrentHealth > 0;

        // Виртуальные действия — можно переопределять
        public virtual void Attack(Character target)
        {
            Console.WriteLine($"{Name} атакует {target.Name}.");
            target.TakeDamage(Damage);
        }

        public virtual void TakeDamage(int amount)
        {
            int real = Math.Max(1, amount - Defense);
            CurrentHealth -= real;
            Console.WriteLine($"{Name} получает {real} урона. (HP {CurrentHealth}/{MaxHealth})");
        }

        // Добавление опыта и прокачка
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
            // Прирост статов — можно переопределить в наследниках
            MaxHealth += 10;
            Damage += 3;
            Defense += 1;
            CurrentHealth = MaxHealth;

            Console.WriteLine($"{Name} достиг уровня {Level}!");
            // уведомление о новых доступных скиллах реализуется в визуализации/логике UI
        }

        // Получить список доступных навыков (разблокированных по уровню)
        public IReadOnlyList<Skills.Skill> GetAvailableSkills()
            => _skills.Where(s => s.RequiredLevel <= Level).ToList().AsReadOnly();

        // Абстрактные методы, реализуемые в наследниках
        public abstract void Draw(); // ASCII-визуализация
        public abstract void UseSkill(int skillIndex, Character target); // использование навыка по индексу

        // Вспомогательные методы
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

        // Добавление скила
        protected void AddSkill(Skills.Skill skill)
        {
            if (skill == null) throw new ArgumentNullException(nameof(skill));
            _skills.Add(skill);
        }
    }
}
