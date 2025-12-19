using RiftBringers.Characters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RiftBringers.Battle
{
    public class Team
    {
        private readonly Character[] _members = new Character[3];

        public IReadOnlyList<Character> Members => _members.ToList().AsReadOnly();

        public void SetMember(int slot, Character hero)
        {
            if (slot < 0 || slot >= _members.Length)
                throw new ArgumentOutOfRangeException(nameof(slot));
            _members[slot] = hero;
        }

        public bool AddMember(Character hero)
        {
            for (int i = 0; i < _members.Length; i++)
            {
                if (_members[i] == null)
                {
                    _members[i] = hero;
                    return true;
                }
            }
            return false; 
        }

        public void RemoveMember(int slot)
        {
            if (slot < 0 || slot >= _members.Length)
                return;
            _members[slot] = null;
        }

        public bool ReplaceMember(int slot, Character newHero)
        {
            if (slot < 0 || slot >= _members.Length)
                return false;
            _members[slot] = newHero;
            return true;
        }

        public bool HasFreeSlots()
        {
            return _members.Any(slot => slot == null);
        }

        public int FreeSlotsCount()
        {
            return _members.Count(slot => slot == null);
        }

        public int OccupiedSlotsCount()
        {
            return _members.Count(slot => slot != null);
        }

        public bool IsAlive() => _members.Any(h => h != null && h.IsAlive);

        public void ResetAll()
        {
            foreach (var h in _members)
                h?.ResetHp();
        }

        public bool HasAliveMembers()
        {
            return _members.Any(character => character != null && character.IsAlive);
        }

        public List<Character> GetAliveMembers()
        {
            return _members.Where(c => c != null && c.IsAlive).ToList();
        }

        
    }
}