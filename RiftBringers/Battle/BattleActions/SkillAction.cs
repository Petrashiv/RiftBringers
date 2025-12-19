using System;
using RiftBringers.Characters;

namespace RiftBringers.Battle
{
    public class SkillAction : BattleAction
    {
        private readonly Skills.Skill _skill;

        public SkillAction(Skills.Skill skill)
        {
            _skill = skill;
        }

        public override string Name => $" {_skill.Name}";
        public override string Description => _skill.Description;
        public override bool NeedsTarget => true;

        public override void Execute(Character user, Character target)
        {
            user.UseSkill(GetSkillIndex(user), target);
        }

        private int GetSkillIndex(Character user)
        {
            var skills = user.GetAvailableSkills().ToList();
            for (int i = 0; i < skills.Count; i++)
            {
                if (skills[i].Name == _skill.Name)
                    return i;
            }
            return 0;
        }
    }
}