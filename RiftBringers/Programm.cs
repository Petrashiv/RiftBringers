using RiftBringers.Battle;
using RiftBringers.Characters;
using RiftBringers.Enemies;
using RiftBringers.Enemy;
using RiftBringers.Events;
using RiftBringers.Items;
using RiftBringers.Storyline;
using System;


namespace RiftBringers {
    class Program
    {
        static void Main()
        {
            
            Introduction.PlayIntroduction();

            
            var playerTeam = new Team();
            playerTeam.SetMember(0, new Warrior());  
            playerTeam.SetMember(1, new Mage());     
            Inventory equipment = new Inventory();

            var enemyTeam = new Team();
            enemyTeam.SetMember(0, new Goblin());
            enemyTeam.SetMember(1, new Goblin());
            enemyTeam.SetMember(2, new Goblin());

            var battleManager = new BattleManager(playerTeam, enemyTeam);
            battleManager.StartBattle();
            playerTeam.RemoveMember(1);
            bool victory = playerTeam.HasAliveMembers();
            Introduction.PlayAfterFirstBattle(victory);

            if (victory)
            {
                Introduction.PlayTownArrival();
                var hubEvent = new StartingHubEvent(playerTeam, equipment);
                hubEvent.Run();
                
            }
            var Amulet = new EternalAmulet();
            equipment.EquipItem(Amulet);
            var Pants = new ShadowPants();
            equipment.EquipItem(Pants);
            equipment.DisplayEquipmentVisual();
        }
    }
}
