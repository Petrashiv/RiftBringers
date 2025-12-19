using RiftBringers;
using RiftBringers.Characters;
using RiftBringers.Skills;
using System.Reflection.Emit;
using System.Xml.Linq;
namespace RiftBringers.Enemies
{
    public class Kobold : Character
    {
        private int _trapCount = 0;

        public Kobold()
            : base("Kobold",
                   " обольд: хитрый и технически подкованный враг, использующий ловушки.",
                   Rarity.Rare,
                   baseHealth: 85, baseDamage: 18, baseDefense: 5)
        {
            AddSkill(new Skills.Skill("Trap Setup", "”станавливает ловушку: следующий атакующий получает 15 урона.", 1,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} устанавливает хитрую ловушку!");
                    _trapCount++;
                    Console.WriteLine($"Ћовушек установлено: {_trapCount}");
                }));

            AddSkill(new Skills.Skill("Ambush", "«асада: наносит 140% урона, если у противника меньше 50% HP.", 3,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} готовит засаду!");

                    int bonusMultiplier = (target.CurrentHealth * 2 < target.MaxHealth) ? 2 : 1;
                    int dmg = (int)(user.Damage * 1.4 * bonusMultiplier);

                    if (bonusMultiplier > 1)
                    {
                        Console.WriteLine("«асада особенно эффективна против ослабленного врага!");
                    }

                    target.TakeDamage(dmg);
                }));

            AddSkill(new Skills.Skill("Kobold Ingenuity", "»зобретательность кобольда: создаЄт щит на 10 HP и увеличивает защиту на 3.", 4,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} использует свою изобретательность!");

                    // —оздание временного щита
                    int shieldAmount = 10;
                    user.CurrentHealth = Math.Min(user.MaxHealth, user.CurrentHealth + shieldAmount);

                    // ”величение защиты
                    user.Defense += 3;

                    Console.WriteLine($"{user.Name} получает щит на {shieldAmount} HP и увеличивает защиту.");
                }));
        }

        public override string[] Draw()
        {
            return new string[] {
                "  /  ",
                " /|||||>",
                " /\\/\\ ",
                $" {Name} ",
                $"[Lv. {Level}]",
                $"HP: {CurrentHealth}/{MaxHealth}",

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

            // јктиваци€ ловушек при атаке
            if (_trapCount > 0 && skillIndex != 0) // Ќе активируем при установке ловушки
            {
                Console.WriteLine($"—рабатывает {_trapCount} ловушк(а/и)!");
                target.TakeDamage(15 * _trapCount);
                _trapCount = 0;
            }

            var skill = avail[skillIndex];
            skill.Use(this, target);
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
        
        public override void TakeDamage(int damage)
        {
            
            if (_trapCount > 0)
            {
                Console.WriteLine("Ћовушка кобольда срабатывает при атаке!");
                
                _trapCount--;
            }

            int real = Math.Max(1, damage - Defense);
            CurrentHealth -= real;
            Console.WriteLine($"{Name} получает {real} урона. (HP {CurrentHealth}/{MaxHealth})");
        }
    }
}
