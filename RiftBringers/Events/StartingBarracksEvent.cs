using System;
using RiftBringers.Characters;
using RiftBringers.Battle;

namespace RiftBringers.Events
{
    public class StartingBarracksEvent : GameEvent
    {
        private Team _playerTeam;

        
        public StartingBarracksEvent(Team playerTeam)
            : base("КАЗАРМЫ ИСКАТЕЛЕЙ",
                  "Штаб-квартира Гильдии Искателей. Здесь набирают команду для опасных миссий.\n" +
                  "Вы можете выбрать одного компаньона для своего путешествия.\n" +
                  "Каждый персонаж имеет свой уровень, редкость и уникальные способности.")
        {
            _playerTeam = playerTeam ?? throw new ArgumentNullException(nameof(playerTeam));
        }

        public override void Run()
        {
            ShowHeader();

            

            Console.WriteLine("\nКапитан Гильдии, ветеран многих битв, предлагает:");
            Console.WriteLine("\"Искатель, один в поле не воин. Выбери себе напарника.\"");
            Console.WriteLine("\"Но помни - опытный воин может быть уже уставшим от битв,\"");
            Console.WriteLine("\"а молодой энтузиаст только набирается сил.\"");

            WaitForContinue();

            Character selectedCompanion = ShowCompanionsMenu();

            if (selectedCompanion != null)
            {
                
                bool added = _playerTeam.AddMember(selectedCompanion);
                
                if (added)
                {
                    Console.WriteLine($"\n {selectedCompanion.Name} присоединился к вашей команде!");
                    Console.WriteLine($"Занято слотов: {_playerTeam.OccupiedSlotsCount()}/3");
                }
                else
                {
                    Console.WriteLine($"\n Не удалось добавить {selectedCompanion.Name}!");
                    Console.WriteLine("Все слоты заняты. Хотите кого-то заменить?");

                    
                    Console.WriteLine("(Пока просто возвращаемся на площадь)");
                }
            }

            Console.WriteLine("\nКапитан хлопает вас по плечу:");
            Console.WriteLine("\"Хороший выбор! Береги друг друга там.\"");
            Console.WriteLine("\"И помни - сила команды в единстве.\"");

            WaitForContinue();
        }

        private Character ShowCompanionsMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(" ВЫБЕРИТЕ КОМПАНЬОНА ");
            Console.ResetColor();

            // Компаньон 1: Редкий, 10 уровень
            Console.WriteLine("\n1.   СИР ГАРРЕТ - ВЕТЕРАН-ВОИН");
            Console.WriteLine("   Уровень: 10 | Редкость: Редкий");
            Console.WriteLine("   Здоровье: 250 | Урон: 35 | Защита: 20");
            Console.WriteLine("   Умения: ЩИТОВОЙ УДАР, БРОНЯ ВЕТЕРАНА");
            Console.WriteLine("   \"Прошел 50 битв, знает все уловки\"");

            // Компаньон 2: Легендарный, 1 уровень
            Console.WriteLine("\n2.  ЛИРАЭЛЬ - ПРОРОК РАЗЛОМА");
            Console.WriteLine("   Уровень: 1 | Редкость: Легендарный");
            Console.WriteLine("   Здоровье: 100 | Урон: 20 | Защита: 8");
            Console.WriteLine("   Умения: ЭХО РАЗЛОМА, ПРОЗРЕНИЕ, ПРИЗЫВ ТЕНИ");
            Console.WriteLine("   \"Молод, но связан с силами Разлома\"");

            

            Console.Write("\nВаш выбор (1-2): ");

            int choice = GetNumberInput(1, 2);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nВы выбрали СИРА ГАРРЕТА");
                    Console.WriteLine("Опытный воин присоединился к вашей команде!");
                    return CreateSirGarrett();

                case 2:
                    Console.WriteLine("\nВы выбрали ЛИРАЭЛЬ");
                    Console.WriteLine("Таинственный пророк теперь ваш союзник!");
                    return CreateLirael();

                

                default:
                    return null;
            }
        }

        private Character CreateSirGarrett()
        {
            // Редкий, 10 уровень
            return new Warrior();
            


        }

        private Character CreateLirael()
        {
            // Легендарный, 1 уровень
            return new Prorok();
                
        }
    }
}