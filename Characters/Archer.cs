using System;

namespace RiftBringers.Characters
{
    public class Archer : Character
    {
        public Archer()
            : base("Archer",
                   "Лучник: мобильный и умеющий критические выстрелы.",
                   Rarity.Common,
                   baseHealth: 100, baseDamage: 25, baseDefense: 5)
        {
            AddSkill(new Skills.Skill("Double Shot", "Двойной выстрел (два раза по урону).", 2,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} делает Double Shot!");
                    target.TakeDamage(user.Damage);
                    target.TakeDamage(user.Damage);
                }));

            AddSkill(new Skills.Skill("Piercing Arrow", "Игнорирует часть защиты противника.", 8,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} стреляет Piercing Arrow!");
                    target.TakeDamage(user.Damage + 10);
                }));
        }

        public override void Draw()
        {
            Console.WriteLine("  -> ");
            Console.WriteLine(" /|  ");
            Console.WriteLine(" / \\ ");
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
