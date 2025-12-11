using System;

namespace RiftBringers.Progression
{
    public static class PrestigeManager
    {
        // ѕрестижный множитель (1.0 = без престижа)
        private static double _multiplier = 1.0;

        public static double PrestigeMultiplier => _multiplier;

        // +0.1 (10%) при каждом добавлении
        public static void AddPrestige()
        {
            _multiplier += 0.1;
            Console.WriteLine($"[Prestige] добавлен: новый множитель = {_multiplier:F2}");
        }

        // ѕрименить престиж к базовой целочисленной характеристике
        public static int ApplyPrestige(int baseValue)
        {
            return (int)Math.Round(baseValue * _multiplier);
        }

        // “естовый/вспомогательный сброс (internal)
        internal static void ResetPrestige()
        {
            _multiplier = 1.0;
        }
    }
}
