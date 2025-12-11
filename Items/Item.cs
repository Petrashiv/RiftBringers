namespace RiftBringers.Items
{
    // Базовый абстрактный класс предмета
    public abstract class Item
    {
        public string Name { get; }
        public string Description { get; }

        protected Item(string name, string description = "")
        {
            Name = name;
            Description = description;
        }

        // Использование предмета персонажем
        public abstract void Use(Characters.Character user);
    }
}
