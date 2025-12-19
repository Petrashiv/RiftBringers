using System;
using RiftBringers.Visual;
using RiftBringers.Characters;
namespace RiftBringers.Enemies
{
    public class Skeleton : Character
    {
        private bool _bonesReassembled = false;

        public Skeleton()
            : base("Skeleton",
                   "Скелет: нежить, устойчивая к физическому урону и способная к регенерации.",
                   Rarity.Rare,
                   baseHealth: 95, baseDamage: 22, baseDefense: 6)
        {
            // Скелеты имеют повышенную базовую защиту
            Defense += 2;

            AddSkill(new Skills.Skill("Bone Throw", "Бросок кости: наносит 110% урона и игнорирует 30% защиты цели.", 2,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} швыряет в врага острые кости!");

                    int targetDefense = target.Defense;
                    int ignoredDefense = (int)(targetDefense * 0.3);
                    int effectiveDefense = targetDefense - ignoredDefense;

                    int dmg = (int)(user.Damage * 1.1);
                    int finalDamage = Math.Max(1, dmg - effectiveDefense);

                    Console.WriteLine($"Атака игнорирует {ignoredDefense} защиты.");
                    target.TakeDamage(finalDamage);
                }));

            AddSkill(new Skills.Skill("Reassemble Bones", "Собирает кости заново: восстанавливает 25 HP.", 3,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} начинает собирать свои кости заново!");

                    if (!_bonesReassembled)
                    {
                        user.CurrentHealth = Math.Min(user.MaxHealth, user.CurrentHealth + 25);
                        _bonesReassembled = true;
                        Console.WriteLine($"{user.Name} восстанавливает 25 HP.");
                    }
                    else
                    {
                        Console.WriteLine("Кости уже были собраны ранее!");
                        user.CurrentHealth = Math.Min(user.MaxHealth, user.CurrentHealth + 10);
                        Console.WriteLine($"{user.Name} восстанавливает 10 HP.");
                    }
                }));

            AddSkill(new Skills.Skill("Death Grip", "Хватка смерти: наносит 130% урона и снижает скорость атаки цели.", 4,
                (user, target) =>
                {
                    Console.WriteLine($"{user.Name} использует леденящую хватку смерти!");

                    int dmg = (int)(user.Damage * 1.3);
                    target.TakeDamage(dmg);

                    // Эффект замедления (в реальной игре здесь был бы статус-эффект)
                    Console.WriteLine($"{target.Name} чувствует замедление от ледяного прикосновения.");
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
                $"HP: {CurrentHealth}/{MaxHealth}",
                
            };
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

            // Скелеты иногда восстанавливают HP при использовании навыков
            Random rnd = new Random();
            if (rnd.Next(0, 100) < 20 && skillIndex != 1) // 20% шанс, кроме Reassemble Bones
            {
                int healAmount = 5;
                CurrentHealth = Math.Min(MaxHealth, CurrentHealth + healAmount);
                Console.WriteLine($"{Name} восстанавливает {healAmount} HP от магии нежити.");
            }

            skill.Use(this, target);
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
        public override void TakeDamage(int damage)
        {
            // Скелеты получают меньше физического урона
            int reducedDamage = (int)(damage * 0.8); // 20% снижение физического урона
            Console.WriteLine($"{Name} получает меньше урона благодаря костяной броне.");

            base.TakeDamage(reducedDamage);

            // Шанс не получить урон из-за промаха по костям
            Random rnd = new Random();
            if (rnd.Next(0, 100) < 5) // 5% шанс
            {
                Console.WriteLine($"Атака проходит сквозь кости {Name} без вреда!");
                CurrentHealth += reducedDamage; // Отмена урона
            }
        }
    }
}
