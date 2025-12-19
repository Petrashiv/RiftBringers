using System;
using RiftBringers.Characters;

namespace RiftBringers.Battle
{
    public class AttackAction : BattleAction
    {
        public override string Name => " Атака";
        public override string Description => "Нанести урон противнику";
        public override bool NeedsTarget => true;

        public override void Execute(Character user, Character target)
        {
            user.Attack(target);
        }
    }
}