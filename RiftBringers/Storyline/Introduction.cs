using System;
using RiftBringers.Characters;

namespace RiftBringers.Storyline
{
    public static class Introduction
    {
        public static void PlayIntroduction()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.WriteLine("                     RIFT BRINGERS                            ");
            Console.WriteLine("                     Пробуждение                              ");
            
            Console.ResetColor();

            WaitForEnter();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("[Темный лес. Ночь. Вы лежите без сознания.]\n");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("???");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Эй! Проснись! Здесь небезопасно!");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВы");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*медленно открываете глаза*");
            Console.WriteLine("Где я... Что случилось?");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nНезнакомец");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Вижу, портал тебя хорошенько потрепал.");
            Console.WriteLine("Меня зовут Элрик. Я следопыт из Гильдии Искателей.");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВы");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Портал? Я ничего не помню...");
            Console.WriteLine("Только какие-то обрывки... Разлом... Монстры...");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nЭлрик");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Разлом Рифта. Да, это он.");
            Console.WriteLine("Он появляется в разных местах и выпускает тварей.");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВы");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("А кто ты? Искатель чего?");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nЭлрик");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Искатели закрываем Разломы.");
            Console.WriteLine("Собираем артефакты, защищаем деревни...");
            Console.WriteLine("В общем, делаем этот мир чуть безопаснее.");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n*Хруст веток*");
            Console.WriteLine("*Низкое рычание*");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nЭлрик");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Черт! Они нас нашли!");
            Console.WriteLine("Гоблины из Разлома. Приготовься!");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВы");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Но у меня нет оружия!");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nЭлрик");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*бросает тебе старый меч*");
            Console.WriteLine("Держи! Будет тяжело, но у нас нет выбора!");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n*Из кустов выскакивают три фигуры*");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nГоблин");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Грррааа! Свежее мясо!");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nЭлрик");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Спиной к спине! Я прикрою твой фланг!");
            Console.WriteLine("Покажи им, на что способен Воин Разлома!");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВы");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*хватаете меч* Ладно... Пора в бой!");
            WaitForEnter();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            
            Console.WriteLine("                   ПЕРВЫЙ БОЙ                               ");
            Console.WriteLine("             Вы и Элрик против гоблинов                     ");
            
            Console.ResetColor();

            Console.WriteLine("\nНажмите Enter чтобы начать битву...");
            Console.ReadLine();
        }

        private static void WaitForEnter()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n[Нажмите Enter чтобы продолжить...]");
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void PlayAfterFirstBattle(bool victory)
        {
            Console.Clear();

            if (victory)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                
                Console.WriteLine("                    ПОСЛЕ БОЯ                                ");
                
                Console.ResetColor();

                Console.WriteLine("\n*Гоблины повержены. В лесу воцарилась тишина.*");
                WaitForEnter();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nЭлрик");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Неплохо для новичка! У тебя есть потенциал.");
                WaitForEnter();

                Console.WriteLine("*Элрик осматривает останки гоблинов*");
                WaitForEnter();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nЭлрик");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Смотри, они носили эти амулеты.");
                Console.WriteLine("Значит Разлом рядом. Он их призывает.");
                WaitForEnter();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nВы");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Что нам делать?");
                WaitForEnter();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nЭлрик");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Идем в ближайшую деревню - Тенистый Перевал.");
                Console.WriteLine("Нужно предупредить жителей и собрать информацию.");
                WaitForEnter();

                Console.WriteLine("И... *смотрит на тебя* хочешь присоединиться?");
                Console.WriteLine("Гильдии нужны такие бойцы как ты.");
                WaitForEnter();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nВы");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("У меня ведь нет выбора, да?");
                Console.WriteLine("Если эти твари могут появиться снова...");
                WaitForEnter();

                Console.WriteLine("Ладно. Я с вами.");
                WaitForEnter();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nЭлрик");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Отлично! Добро пожаловать в Искатели!");
                Console.WriteLine("*протягивает руку*");
                WaitForEnter();

                Console.WriteLine("Теперь в путь. До деревни полдня ходьбы.");
                Console.WriteLine("Будь настороже - в лесу еще много опасностей.");
                WaitForEnter();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nТак начинается ваше путешествие в качестве Искателя Разломов.");
                Console.WriteLine("Впереди - много битв, открытий и загадок Рифта...");
                Console.ResetColor();
                WaitForEnter();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                
                Console.WriteLine("                   ГРУСТНЫЙ КОНЕЦ                           ");
                
                Console.ResetColor();

                Console.WriteLine("\n*Вы падаете без сознания. Гоблины празднуют победу.*");
                WaitForEnter();

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nГоблин");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Хи-хи! Еда на два дня!");
                WaitForEnter();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nИгра окончена. Попробуйте еще раз!");
                Console.ResetColor();
                WaitForEnter();
            }
        }

        public static void PlayTownArrival()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.WriteLine("                   ТЕНИСТЫЙ ПЕРЕВАЛ                          ");
            Console.WriteLine("                   Добро пожаловать!                         ");
            
            Console.ResetColor();

            Console.WriteLine("\n*Вы с Элриком входите в небольшую деревушку.*");
            WaitForEnter();

            Console.WriteLine("*Жители смотрят на вас с беспокойством и надеждой.*");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nСтарейшина");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Элрик! Слава богам, ты вернулся!");
            Console.WriteLine("И с новым бойцом...");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nЭлрик");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Да, Гарольд. Это новый Искатель.");
            Console.WriteLine("Разлом активизировался. Нас атаковали гоблины.");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nСтарейшина Гарольд");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Опять... Уже третья атака за неделю.");
            Console.WriteLine("Люди боятся выходить из домов.");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nЭлрик");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Мы закроем Разлом. Но нужна информация.");
            Console.WriteLine("Кто-нибудь видел, откуда они появляются?");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nМолодой охотник");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Я видел! В Старой Пещере!");
            Console.WriteLine("Там странное сияние... и эти твари...");
            WaitForEnter();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nЭлрик");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Старая Пещера... Помню ее.");
            Console.WriteLine("Но я оставлю тебя, у меня много дел.");
            WaitForEnter();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВы");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Но как я один смогу их победить?");
            Console.WriteLine("Я сам то ничего не умею.");
            WaitForEnter();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nЭлрик");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Почему один?");
            Console.ForegroundColor = ConsoleColor.Cyan;
            WaitForEnter();

            Console.WriteLine("   В местах отдыха вы можете нанять новых союзников и купить снаряжение.    ");
            Console.WriteLine("   Начинайте свой путь и добейтесь цели!    ");

            Console.ResetColor();
            WaitForEnter();
            
            
        }
    }
}