using System;

namespace RiftBringers.Items
{
    public class Inventory
    {
        private readonly Item[] _slots;

        public int Size => _slots.Length;

        public Inventory(int size)
        {
            if (size <= 0) throw new ArgumentException("Size must be > 0", nameof(size));
            _slots = new Item[size];
        }

        // Попытаться положить предмет — возвращает индекс или -1
        public int AddItem(Item item)
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i] == null)
                {
                    _slots[i] = item;
                    return i;
                }
            }
            return -1;
        }

        public Item GetItem(int index)
        {
            if (index < 0 || index >= _slots.Length) return null;
            return _slots[index];
        }

        public void RemoveItem(int index)
        {
            if (index < 0 || index >= _slots.Length) return;
            _slots[index] = null;
        }

        // Печать инвентаря (для отладки / консоли)
        public void Print()
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                var name = _slots[i] != null ? _slots[i].Name : "[Пусто]";
                Console.WriteLine($"{i + 1}: {name}");
            }
        }
    }
}
