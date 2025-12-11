using System;
using System.Linq;

namespace RiftBringers.Battle
{
    public class Team
    {
        private readonly Characters.Character[] _members = new Characters.Character[3];

        public IReadOnlyList<Characters.Character> Members => _members.ToList().AsReadOnly();

        public void SetMember(int slot, Characters.Character hero)
        {
            if (slot < 0 || slot >= _members.Length) throw new ArgumentOutOfRangeException(nameof(slot));
            _members[slot] = hero;
        }

        public bool IsAlive() => _members.Any(h => h != null && h.IsAlive);

        public void ResetAll()
        {
            foreach (var h in _members) h?.ResetHp();
        }

        public void PrintRoster()
        {
            for (int i = 0; i < _members.Length; i++)
            {
                var h = _members[i];
                Console.WriteLine($"{i + 1}: {(h != null ? h.Name + $" (Lv{h.Level})" : "[Пусто]")}");
            }
        }
    }
}
