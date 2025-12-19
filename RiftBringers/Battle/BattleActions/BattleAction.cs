using System;
using RiftBringers.Characters;

namespace RiftBringers.Battle
{
    public abstract class BattleAction
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract bool NeedsTarget { get; }

        public abstract void Execute(Character user, Character target);
    }

    

    

    
}