using System;
using RiftBringers.Characters;

namespace RiftBringers.Battle
{
    public class DefendAction : BattleAction
    {
        public override string Name => " Защита";
        public override string Description => "Увеличить защиту в 2 раза на этот ход";
        public override bool NeedsTarget => false;

        public override void Execute(Character user, Character target)
        {
            user.Defend();
            user.IsDefending = true;


        }
    }
}