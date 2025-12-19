using System;
using RiftBringers.Characters;
using RiftBringers.Items;

namespace RiftBringers.Events
{
    public class StartingForgeEvent : GameEvent
    {
        private Inventory _equipment;

        // Конструктор принимает экипировку
        public StartingForgeEvent(Inventory equipment)
            : base("КУЗНИЦА 'СТАЛЬ И ПАМЯТЬ'",
                  "Старая кузница на окраине деревни. Здесь можно получить снаряжение для вашего персонажа.\n" +
                  "У вас 6 слотов для экипировки: голова, грудь, руки, ноги, оружие, аксессуар.\n" +
                  "Вы можете выбрать один предмет для начала вашего путешествия.")
        {
            _equipment = equipment ?? throw new ArgumentNullException(nameof(equipment));
        }

        public override void Run()
        {
            ShowHeader();

            Console.WriteLine("Старый кузнец Осрик смотрит на вас:");
            Console.WriteLine("\"Вижу, собрался в опасный путь. Возьми что-нибудь из моего старого добра.\"");
            Console.WriteLine("\"Выбирай с умом - хорошее снаряжение спасло не одну жизнь.\"");

            WaitForContinue();

            Item selectedItem = ShowItemsMenu();

            if (selectedItem != null)
            {
                // Добавляем выбранный предмет в экипировку
                bool equipped = _equipment.EquipItem(selectedItem);

                if (equipped)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n {selectedItem.Name} добавлен в вашу экипировку!");
                    selectedItem.Use();
                    Console.ResetColor();

                    // Показываем обновленную экипировку
                    Console.WriteLine("\n ВАША ЭКИПИРОВКА ");
                    _equipment.DisplayEquipment();
                }
            }

            Console.WriteLine("\nОсрик кивает:");
            Console.WriteLine("\"Хороший выбор. Удачи в пути, путник.\"");
            Console.WriteLine("\"Возвращайся, если понадобится починить или улучшить.\"");

            WaitForContinue();
        }

        private Item ShowItemsMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(" ВЫБЕРИТЕ ПРЕДМЕТ ");
            Console.ResetColor();

            // Предмет 1: Шлем
            Console.WriteLine("\n1.  ШЛЕМ СТАЛЬНОГО ДУХА");
            Console.WriteLine("   Тип: Шлем");
            Console.WriteLine("   Редкость: Обычный");
            Console.WriteLine("   Бонусы: +30 HP, +5 защиты");
            Console.WriteLine("   Описание: Стальной шлем с рунами защиты");

            // Предмет 2: Меч
            Console.WriteLine("\n2.  МЕЧ ПРОБУЖДЕНИЯ");
            Console.WriteLine("   Тип: Оружие");
            Console.WriteLine("   Редкость: Редкий");
            Console.WriteLine("   Бонусы: +15 урона");
            Console.WriteLine("   Описание: Закаленный клинок, светящийся в темноте");

            // Предмет 3: Ботинки
            Console.WriteLine("\n3.  БОТИНКИ СТРАННИКА");
            Console.WriteLine("   Тип: Сапоги");
            Console.WriteLine("   Редкость: Обычный");
            Console.WriteLine("   Бонусы: +15 HP, +3 защиты");
            Console.WriteLine("   Описание: Прочные ботинки для долгих путешествий");

            // Показываем текущую экипировку
            Console.WriteLine("\n ТЕКУЩАЯ ЭКИПИРОВКА ");
            _equipment.DisplayEquipment();

            Console.Write("\nВаш выбор (1-3): ");
            int choice = GetNumberInput(1, 3);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nВы выбрали ШЛЕМ СТАЛЬНОГО ДУХА");
                    return CreateSteelHelmet();

                case 2:
                    Console.WriteLine("\nВы выбрали МЕЧ ПРОБУЖДЕНИЯ");
                    return CreateSteelSword();

                case 3:
                    Console.WriteLine("\nВы выбрали БОТИНКИ СТРАННИКА");
                    return CreateLeatherBoots();

                default:
                    return null;
            }
        }

        private Item CreateSteelHelmet()
        {
            return new SteelHelmetOfSpirit();


        }

        private Item CreateSteelSword()
        {
            return new AwakeningSword();
            
        }

        private Item CreateLeatherBoots()
        {
            return new WandererBoots();
            
        }

        
    }
}