using System;
using System.Collections.Generic;
using System.Linq;
using RiftBringers.Characters;

namespace RiftBringers.Battle
{
    public class BattleManager
    {
        private readonly Team _playerTeam;
        private readonly Team _enemyTeam;
        private int _currentTurn = 0;
        

        public BattleManager(Team playerTeam, Team enemyTeam)
        {
            _playerTeam = playerTeam;
            _enemyTeam = enemyTeam;
        }

        public void StartBattle()
        {
            Console.WriteLine("=== БОЙ НАЧИНАЕТСЯ ===");
            Console.WriteLine("Нажмите Enter для начала хода...");
            Console.ReadLine();
            BattleRenderer.RenderBattlefield(_playerTeam, _enemyTeam);
            while (_playerTeam.HasAliveMembers() && _enemyTeam.HasAliveMembers())
            {
                _currentTurn++;
                Console.WriteLine($"\n=== ХОД {_currentTurn} ===");

                // Ход игрока
                PlayerTurn();

                if (!_enemyTeam.HasAliveMembers()) break;

                // Ход врага
                EnemyTurn();

                Console.WriteLine("\nНажмите Enter для продолжения...");
                Console.ReadLine();
            }

            EndBattle();
        }

        private void PlayerTurn()
        {
            Console.WriteLine("\n--- ХОД ИГРОКА ---");
            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();

            foreach (var character in _playerTeam.Members.Where(c => c != null && c.IsAlive))
            {
                CharacterTurn(character, _enemyTeam, isPlayer: true);

                if (!_enemyTeam.HasAliveMembers()) break;
            }

            BattleRenderer.RenderBattlefield(_playerTeam, _enemyTeam);
        }

        private void EnemyTurn()
        {
            Console.WriteLine("\n--- ХОД ПРОТИВНИКА ---");
            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();

            foreach (var character in _enemyTeam.Members.Where(c => c != null && c.IsAlive))
            {
                CharacterTurn(character, _playerTeam, isPlayer: false);

                if (!_playerTeam.HasAliveMembers()) break;
            }
            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();
            BattleRenderer.RenderBattlefield(_playerTeam, _enemyTeam);
        }

        private void CharacterTurn(Character character, Team targetTeam, bool isPlayer)
        {
            Console.WriteLine($"\n[ХОД {character.Name}]");

            if (isPlayer)
            {
                // Игрок выбирает действие
                PlayerChooseAction(character, targetTeam);
            }
            else
            {
                // AI для врага
                EnemyChooseAction(character, targetTeam);
            }
        }

        private void PlayerChooseAction(Character character, Team targetTeam)
        {
            if (character.IsDefending)
            {
                character.UnDefend();
                character.IsDefending = false;
            }
            var actions = GetAvailableActions(character);

            Console.WriteLine("\nВыберите действие:");
            for (int i = 0; i < actions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {actions[i].Name}");
            }

            int choice = GetValidChoice(1, actions.Count);
            var selectedAction = actions[choice - 1];

            // Выбираем цель, если нужно
            Character target = null;
            if (selectedAction.NeedsTarget)
            {
                target = SelectTarget(targetTeam);
                if (target == null) return; // Отмена
            }

            // Выполняем действие
            selectedAction.Execute(character, target);
        }

        private void EnemyChooseAction(Character character, Team targetTeam)
        {
            // Простая AI логика
            var aliveTargets = targetTeam.Members.Where(c => c != null && c.IsAlive).ToList();
            if (aliveTargets.Count == 0) return;

            var target = aliveTargets[0]; // Атакуем первого живого
            if (character.IsDefending)
            {
                character.UnDefend();
                character.IsDefending = false;
            }
            // 70% шанс атаки, 30% защиты
            if (new Random().Next(1, 101) <= 70)
            {
                
                character.Attack(target);
            }
            else
            {
                
                character.Defend();
                character.IsDefending = true;
            }
        }

        private List<BattleAction> GetAvailableActions(Character character)
        {
            var actions = new List<BattleAction>
            {
                new AttackAction(),
                new DefendAction()
            };

            // Добавляем умения персонажа
            var skills = character.GetAvailableSkills();
            foreach (var skill in skills)
            {
                actions.Add(new SkillAction(skill));
            }

            return actions;
        }

        private Character SelectTarget(Team targetTeam)
        {
            var aliveTargets = targetTeam.Members.Where(c => c != null && c.IsAlive).ToList();

            Console.WriteLine("\nВыберите цель:");
            for (int i = 0; i < aliveTargets.Count; i++)
            {
                var target = aliveTargets[i];
                Console.WriteLine($"{i + 1}. {target.Name} (HP: {target.CurrentHealth}/{target.MaxHealth})");
            }

            Console.WriteLine($"{aliveTargets.Count + 1}. Отмена");

            int choice = GetValidChoice(1, aliveTargets.Count + 1);

            if (choice == aliveTargets.Count + 1)
                return null;

            return aliveTargets[choice - 1];
        }

        private int GetValidChoice(int min, int max)
        {
            int choice;
            while (true)
            {
                Console.Write($"Введите число ({min}-{max}): ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine("Неверный выбор!");
            }
        }

        private void EndBattle()
        {
            Console.WriteLine("\n=== БОЙ ЗАВЕРШЕН ===");

            if (_playerTeam.HasAliveMembers())
            {
                Console.WriteLine(" ПОБЕДА! Все враги повержены!");

                // Награда за победу
                foreach (var character in _playerTeam.Members.Where(c => c != null && c.IsAlive))
                {
                    character.AddExperience(100);
                    Console.WriteLine($"{character.Name} получает 100 опыта!");
                }
            }
            else
            {
                Console.WriteLine(" ПОРАЖЕНИЕ... Все ваши персонажи пали.");
            }

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }
    }
}