using System;
using RiftBringers.Visual;
namespace RiftBringers.Characters
{
    public class Mage : Character
    {
        public Mage()
            : base("Mage",
                   "ћаг: сильный атакующий на рассто€нии.",
                   Rarity.Epic,
                   baseHealth: 90, baseDamage: 30, baseDefense: 3)
        {
            AddSkill(new Skills.Skill("Fireball", "ќгненный шар: +15 урона.", 2,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} кастует Fireball!");
                    target.TakeDamage(user.Damage + 15);
                }));

            AddSkill(new Skills.Skill("Ice Blast", "«амораживающий взрыв: 120% урона.", 5,
                (user, target) =>
                {
                    int dmg = (int)(user.Damage * 1.2);
                    Console.WriteLine($"{user.Name} использует Ice Blast!");
                    target.TakeDamage(dmg);
                    // можно добавить дебаф заморозки
                }));
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
        public override string[] Draw()
        {
            
            return new string[]
            {
                "  ^  ",
                " / \\ ",
                " \\_/ ",
                $"{Name} ",
                $"[Lv. {Level}]",
                $"HP: {CurrentHealth}/{MaxHealth}"
            };
            
            
            
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
