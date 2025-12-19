using System;

namespace RiftBringers.Events
{
    
    public abstract class GameEvent
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        protected GameEvent(string name, string description)
        {
            Name = name;
            Description = description;
        }

        // Абстрактный метод запуска ивента
        public abstract void Run();

        // Общий метод для отображения заголовка
        protected void ShowHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.WriteLine($"                    {Name}                    ");
           
            Console.ResetColor();

            Console.WriteLine($"\n{Description}");
            Console.WriteLine();
        }

        // Общий метод для ожидания ввода
        protected void WaitForContinue()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n[Нажмите Enter чтобы продолжить...] ");
            Console.ResetColor();
            Console.ReadLine();
        }

        // Общий метод для получения числового ввода
        protected int GetNumberInput(int min, int max)
        {
            int choice;
            while (true)
            {
                Console.Write($"Введите число от {min} до {max}: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine("Неверный ввод!");
            }
        }
    }
}