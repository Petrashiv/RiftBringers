using System;

namespace RiftBringers.Characters
{
    public class Mage : Character
    {
        public Mage()
            : base("Mage",
                   "Маг: сильный атакующий на расстоянии.",
                   Rarity.Epic,
                   baseHealth: 90, baseDamage: 30, baseDefense: 3)
        {
            AddSkill(new Skills.Skill("Fireball", "Огненный шар: +15 урона.", 2,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} кастует Fireball!");
                    target.TakeDamage(user.Damage + 15);
                }));

            AddSkill(new Skills.Skill("Ice Blast", "Замораживающий взрыв: 120% урона.", 5,
                (user, target) =>
                {
                    int dmg = (int)(user.Damage * 1.2);
                    Console.WriteLine($"{user.Name} использует Ice Blast!");
                    target.TakeDamage(dmg);
                    // можно добавить дебаф заморозки
                }));
        }

        public override void Draw()
        {
            Console.WriteLine("  ^  ");
            Console.WriteLine(" / \\ ");
            Console.WriteLine(" \\_/ ");
        }

        public override void UseSkill(int skillIndex, Character target)
        {
            var avail = GetAvailableSkills();
            if (skillIndex < 0 || skillIndex >= avail.Count)
            {
                Console.WriteLine("Неверный индекс навыка.");
                return;
            }
            avail[skillIndex].Use(this, target);
        }
    }
}
