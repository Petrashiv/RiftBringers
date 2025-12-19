using System;

namespace RiftBringers.Skills
{
    
    public class Skill
    {
        public string Name { get; }
        public string Description { get; }
        public int RequiredLevel { get; }

        private readonly Action<Characters.Character, Characters.Character> _action;

        public Skill(string name, string description, int requiredLevel,
            Action<Characters.Character, Characters.Character> action)
        {
            Name = name;
            Description = description;
            RequiredLevel = requiredLevel;
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public void Use(Characters.Character user, Characters.Character target)
        {
            _action(user, target);
        }
    }
}
