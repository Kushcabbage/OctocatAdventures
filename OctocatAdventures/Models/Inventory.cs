using System;
using System.Collections.Generic;
using System.Linq;

namespace OctocatAdventures.Models
{
    public class Inventory
    {
        public List<Item> Items { get; private set; } = new List<Item>();

        public int MaxSize { get; private set; }

        public void AddItem(Item item)
        {
            this.Items.Add(item);
        }
    }
}