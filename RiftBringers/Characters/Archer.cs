using RiftBringers.Visual;
using System;
using System.Drawing;
namespace RiftBringers.Characters
{
    public class Archer : Character
    {
        public Archer()
            : base("Archer",
                   "Ћучник: мобильный и умеющий критические выстрелы.",
                   Rarity.Common,
                   baseHealth: 100, baseDamage: 25, baseDefense: 5)
        {
            AddSkill(new Skills.Skill("Double Shot", "ƒвойной выстрел (два раза по урону).", 2,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} делает Double Shot!");
                    target.TakeDamage(user.Damage);
                    target.TakeDamage(user.Damage);
                }));

            AddSkill(new Skills.Skill("Piercing Arrow", "»гнорирует часть защиты противника.", 8,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} стрел€ет Piercing Arrow!");
                    target.TakeDamage(user.Damage + 10);
                }));
        }

        public override string[] Draw()
        {
            
            return new string[]
            {
                "  -> ",
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
            Console.WriteLine($"{Name} защищаетс€!");
            Defense *= 2;
        }
        public override void UnDefend()
        {
            Defense /= 2;
        }
        public override void TakeDamage(int amount)
        {
            int real = Math.Max(1, amount - Defense);
            CurrentHealth -= real;
            Console.WriteLine($"{Name} получает {real} урона. (HP {CurrentHealth}/{MaxHealth})");
        }
        public override void UseSkill(int skillIndex, Character target)
        {
            var avail = GetAvailableSkills();
            if (skillIndex < 0 || skillIndex >= avail.Count)
            {
                Console.WriteLine("Ќеверный индекс навыка.");
                return;
            }
            avail[skillIndex].Use(this, target);
        }
    }
}
