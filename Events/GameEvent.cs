namespace RiftBringers.Events
{
    public abstract class GameEvent
    {
        public string Description { get; protected set; }

        
        public abstract bool Execute(Battle.Team team);
    }
}
