using System;
using RiftBringers.Visual;


namespace RiftBringers.Characters
{
    public class Warrior : Character
    {
        public Warrior()
            : base("Warrior",
                   "Воин: выносливый боец ближнего боя.",
                   Rarity.Rare,
                   baseHealth: 120, baseDamage: 20, baseDefense: 8)
        {
            
            AddSkill(new Skills.Skill("Shield Block", "Снижает входящий урон на 50% в течение 1 хода.", 2,
                ( user, target) =>
                {
                    Console.WriteLine($"{user.Name} использует Shield Block и получает временную защиту.");

                    (user as Warrior)!.Defense += 5;
                }));

            AddSkill(new Skills.Skill("Heavy Slash", "Мощный удар: 150% урона.", 4,
                (user, target) =>
                {
                    int dmg = (int)(user.Damage * 1.5);
                    Console.WriteLine($"{user.Name} применяет Heavy Slash!");
                    target.TakeDamage(dmg);
                }));
        }

        public override string[] Draw()
        {
            

            return new string[] {
                "  O  ",
                " /|\\ ",
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
                Console.WriteLine("Неверный индекс навыка.");
                return;
            }
            var skill = avail[skillIndex];
            skill.Use(this, target);
        }
    }
}
