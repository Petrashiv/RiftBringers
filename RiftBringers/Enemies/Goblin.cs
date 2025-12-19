using System;
using RiftBringers.Visual;
using RiftBringers.Characters;

namespace RiftBringers.Enemy
{
    public class Goblin : Character
    {
        private bool _dirtyTrickUsed = false;

        public Goblin()
            : base("Goblin",
                   "Гоблин: маленький и подлый враг, использующий грязные трюки.",
                   Rarity.Common,
                   baseHealth: 70, baseDamage: 15, baseDefense: 3)
        {
            AddSkill(new Skills.Skill("Dirty Strike", "Грязный удар: наносит 120% урона и снижает защиту цели на 2 на 1 ход.", 2,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} использует грязный трюк!");
                    int dmg = (int)(user.Damage * 1.2);
                    target.TakeDamage(dmg);

                    // Снижение защиты цели
                    if (target is Character characterTarget)
                    {
                        characterTarget.Defense = Math.Max(0, characterTarget.Defense - 2);
                        Console.WriteLine($"Защита {target.Name} снижена на 2.");
                    }
                }));

            AddSkill(new Skills.Skill("Goblin Pack", "Собирает других гоблинов: восстанавливает 20 HP и увеличивает урон на 30% на 2 хода.", 3,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} зовёт на помощь сородичей!");


                    user.CurrentHealth = Math.Min(user.MaxHealth, user.CurrentHealth + 20);
                    Console.WriteLine($"{user.Name} восстанавливает 20 HP.");


                    user.Damage = (int)(user.Damage * 1.3);
                    Console.WriteLine($"Урон {user.Name} увеличен на 30%.");
                }));
        }

        public override string[] Draw()
        {
            return new string[] {
                " /0* ",
                " /|  ",
                " / \\ ",

                $"{Name} ",
                $"[Lv. {Level}]",
                $"HP: {CurrentHealth}/{MaxHealth}"
            };
        }
        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} атакует {target.Name}.");
            target.TakeDamage(Damage);
        }
        public override void Defend()
        {
            Console.WriteLine($"{Name} защищается!");
            Defense *= 2;
        }
        public override void UnDefend()
        {
            Defense /= 2;
        }
        
        public override void UseSkill(int skillIndex, Character target)
        {
            var avail = GetAvailableSkills();
            if (skillIndex < 0 || skillIndex >= avail.Count)
            {
                Console.WriteLine("Неверный индекс навыка.");
                return;
            }
            var skill = avail[skillIndex];

            // Гоблины имеют шанс промахнуться
            Random rnd = new Random();
            if (rnd.Next(0, 100) < 15) // 15% шанс промаха
            {
                Console.WriteLine($"{Name} промахивается из-за своей неуклюжести!");
                return;
            }

            skill.Use(this, target);
        }

        public override void TakeDamage(int damage)
        {
            // Гоблины иногда уворачиваются от атак
            Random rnd = new Random();
            if (rnd.Next(0, 100) < 10) // 10% шанс увернуться
            {
                Console.WriteLine($"{Name} ловко уворачивается от атаки!");
                return;
            }

            int real = Math.Max(1, damage - Defense);
            CurrentHealth -= real;
            Console.WriteLine($"{Name} получает {real} урона. (HP {CurrentHealth}/{MaxHealth})");
        }
    }
}
