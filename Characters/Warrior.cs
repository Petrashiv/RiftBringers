using System;

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
            // Пример добавления навыков (RequiredLevel задаёт минимальный уровень для использования)
            AddSkill(new Skills.Skill("Shield Block", "Снижает входящий урон на 50% в течение 1 хода.", 2,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} использует Shield Block и получает временную защиту.");
                    // Простой эффект: временное повышение защиты (в реальной боевке надо реализовать таймер)
                    // Реализуем простую одноразовую механику: повышаем Defense на 5 один раз
                    user.Defense += 5;
                }));

            AddSkill(new Skills.Skill("Heavy Slash", "Мощный удар: 150% урона.", 4,
                (user, target) =>
                {
                    int dmg = (int)(user.Damage * 1.5);
                    Console.WriteLine($"{user.Name} применяет Heavy Slash!");
                    target.TakeDamage(dmg);
                }));
        }

        public override void Draw()
        {
            Console.WriteLine("  O  ");
            Console.WriteLine(" /|\\ ");
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
            var skill = avail[skillIndex];
            skill.Use(this, target);
        }
    }
}
