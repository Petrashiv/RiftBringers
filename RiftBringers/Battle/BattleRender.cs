using System;
using System.Linq;
using RiftBringers.Characters;
using RiftBringers.Visual;

namespace RiftBringers.Battle
{
    public static class BattleRenderer
    {
        private const int LineWidth = 12;

        public static void RenderBattlefield(Team playerTeam, Team enemyTeam)
        {
            Console.Clear();
            Console.WriteLine("               БОЙ                \n");

            Character[] left = playerTeam.Members.ToArray();
            Character[] right = enemyTeam.Members.ToArray();

            int drawHeight = 6;

            for (int row = 0; row < drawHeight; row++)
            {
                // Левая команда
                foreach (var character in left)
                {
                    DrawLine(character, row);
                    Console.Write("    ");
                }

                Console.ResetColor();
                Console.Write("        ||        ");

                // Правая команда
                foreach (var character in right)
                {
                    DrawLine(character, row);
                    Console.Write("    ");
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }

        private static void DrawLine(Character character, int row)
        {
            if (character == null)
            {
                Console.Write(new string(' ', LineWidth));
                return;
            }

            var draw = character.Draw();
            if (draw == null || row >= draw.Length)
            {
                Console.Write(new string(' ', LineWidth));
                return;
            }

            string line = FormatLine(draw[row]);

            if (line.Contains("[Lv."))
                Console.ForegroundColor = RarityColorHelper.GetColor(character.Rarity);
            else
                Console.ResetColor();

            Console.Write(line);
            Console.ResetColor();
        }

        private static string FormatLine(string line)
        {
            if (line.Length > LineWidth)
                return line.Substring(0, LineWidth);

            return line.PadRight(LineWidth);
        }
    }
}
