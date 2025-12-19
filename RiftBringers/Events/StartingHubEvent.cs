using RiftBringers.Battle;
using RiftBringers.Items;
using System;

namespace RiftBringers.Events
{
    public class StartingHubEvent : GameEvent
    {
        private bool _visitedForge = false;
        private bool _visitedBarracks = false;
        private Team _playerTeam;
        private Inventory _equipment;
        public StartingHubEvent(Team playerTeam, Inventory equipment)
            : base("ПЛОЩАДЬ ПОДГОТОВКИ",
                  "Центральная площадь деревни. Отсюда начинаются все пути.\n" +
                  "Перед тем как отправиться в опасное путешествие, нужно подготовиться:\n" +
                  "1. Посетить кузницу для снаряжения\n" +
                  "2. Найти компаньона в казармах\n" +
                  "Только после этого путь к Разлому будет открыт.")
        {
            _playerTeam = playerTeam ?? throw new ArgumentNullException(nameof(playerTeam));
            _equipment = equipment ?? throw new ArgumentNullException(nameof(equipment));
        }

        public override void Run()
        {
            bool readyToDepart = false;

            while (!readyToDepart)
            {
                ShowHeader();
                ShowStatus();
               

                Console.WriteLine("\nКуда вы хотите пойти?");
                Console.WriteLine("1.  КУЗНИЦА 'Сталь и Память' - получить снаряжение");
                Console.WriteLine("2.  КАЗАРМЫ Искателей - найти компаньона");
                Console.WriteLine("3.  ОТПРАВИТЬСЯ В ПУТЬ - начать путешествие");

                int choice = GetNumberInput(1, 3);

                switch (choice)
                {
                    case 1:
                        if (_visitedForge == false)
                            VisitForge();
                        break;

                    case 2:
                        if (_visitedBarracks == false)
                            VisitBarracks();
                        break;

                    case 3:
                        readyToDepart = TryToDepart();
                        break;
                }

                Console.Clear();
            }

            ShowDepartureScene();
        }

        private void ShowStatus()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n ВАША ПОДГОТОВКА");
            Console.ResetColor();

            Console.Write(" Кузница: ");
            if (_visitedForge)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ПОСЕЩЕНА ");
                Console.ResetColor();
                Console.WriteLine("   • Вы получили стартовое снаряжение");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("НЕ ПОСЕЩЕНА ");
                Console.ResetColor();
                Console.WriteLine("   • Без снаряжения вы уязвимы");
            }

            Console.Write(" Казармы: ");
            if (_visitedBarracks)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ПОСЕЩЕНЫ ");
                Console.ResetColor();
                Console.WriteLine("   • У вас есть верный компаньон");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("НЕ ПОСЕЩЕНЫ ");
                Console.ResetColor();
                Console.WriteLine("   • Один в поле не воин");
            }

            bool isReady = _visitedForge && _visitedBarracks;
            Console.Write(" Готовность: ");

            if (isReady)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ГОТОВ К ПУТИ ");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("НЕ ГОТОВ ");
                Console.ResetColor();
                Console.WriteLine("   • Завершите подготовку!");
            }
        }



        private void VisitForge()
        {
            Console.Clear();
            Console.WriteLine("Вы направляетесь к кузнице...");
            WaitForContinue();

            var forgeEvent = new StartingForgeEvent(_equipment);
            forgeEvent.Run();

            _visitedForge = true;
            Console.WriteLine("\nВы покидаете кузницу с новой экипировкой.");

            

            WaitForContinue();
        }

        private void VisitBarracks()
        {
            Console.Clear();
            Console.WriteLine("Вы направляетесь к казармам...");
            WaitForContinue();

            var barracksEvent = new StartingBarracksEvent(_playerTeam);
            barracksEvent.Run();

            _visitedBarracks = true;
            Console.WriteLine("\nВы покидаете казармы с новым компаньоном.");
            WaitForContinue();
        }

        private bool TryToDepart()
        {
            Console.Clear();

            if (!_visitedForge && !_visitedBarracks)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                
                Console.WriteLine("                    НЕДОСТАТОЧНО ПОДГОТОВЛЕН                  ");
                
                Console.ResetColor();

                Console.WriteLine("\nСтарейшина деревни останавливает вас:");
                Console.WriteLine("\"Куда собрался, безумец?\"");
                Console.WriteLine("\"Без снаряжения и без союзника ты не пройдешь и мили!\"");
                Console.WriteLine("\"Сначала посети кузницу и казармы!\"");

                WaitForContinue();
                return false;
            }
            else if (!_visitedForge)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                
                Console.WriteLine("                 ЗАБЫЛ СНАРЯЖЕНИЕ!                           ");
                
                Console.ResetColor();

                Console.WriteLine("\nКузнец Осрик кричит вам вслед:");
                Console.WriteLine("\"Эй, путник! Ты забыл взять снаряжение!\"");
                Console.WriteLine("\"Как ты собираешься сражаться голыми руками?\"");
                Console.WriteLine("\"Вернись в кузницу!\"");

                WaitForContinue();
                return false;
            }
            else if (!_visitedBarracks)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                
                Console.WriteLine("                 ОДИН В ПОЛЕ НЕ ВОИН                         ");
                
                Console.ResetColor();

                Console.WriteLine("\nКапитан Гильдии преграждает вам путь:");
                Console.WriteLine("\"Стой! Ты забыл самого важного - напарника!\"");
                Console.WriteLine("\"Разлом охраняют не один, а десятки монстров.\"");
                Console.WriteLine("\"Иди в казармы и найди себе компаньона!\"");

                WaitForContinue();
                return false;
            }
            else
            {
                return true; 
            }
        }

        private void ShowDepartureScene()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine("                    ВПЕРЕД, К ПРИКЛЮЧЕНИЯМ!                   ");
            
            Console.ResetColor();

            Console.WriteLine("\nВы стоите у ворот деревни, полностью подготовленный.");
            WaitForContinue();

            Console.WriteLine("За вашей спиной:");
            Console.WriteLine("• Новое снаряжение блестит на солнце");
            Console.WriteLine("• Верный компаньон готов сражаться рядом");
            WaitForContinue();

            

            Console.WriteLine("\nСтарейшина подходит к вам:");
            Console.WriteLine("\"Теперь ты готов, путник.\"");
            Console.WriteLine("\"Разлом ждет. Мир нуждается в героях.\"");
            Console.WriteLine("\"Иди, и да удача будет с тобой!\"");
            WaitForContinue();

            Console.WriteLine("\nВы делаете шаг вперед.");
            Console.WriteLine("Ворота скрипят и открываются.");
            Console.WriteLine("Путь к Разлому начинается...");
            WaitForContinue();
        }
    }
}