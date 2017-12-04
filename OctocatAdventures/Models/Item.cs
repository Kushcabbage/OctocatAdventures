using System;
using System.Collections.Generic;
using System.Linq;
using OctocatAdventures.Models.Location;

namespace OctocatAdventures.Models
{
    public class Item
    {
        public string Name { get; }

        public string Desc { get; }

        public bool Hidden { get; }
        //public int Cost { get; }

        public static List<Item> Items = new List<Item>()
        {
            new Item("flask","keeps drinks warm")
        };

        public static void Declareitems()
        {
           
        }



        public static Dictionary<string, Place> ItemPlaces = new Dictionary<string, Place>()                 //places are in lower case for validation
        {

            {Items[0].Name,Place.SouthCourts },



        };

        public static Dictionary<Place, Item> Seeitems = new Dictionary<Place, Item>()                 //places are in lower case for validation
        {

            {Place.SouthCourts,Items[0] },



        };




        public Item(string name, string desc)
        {
            Name = name;
            Desc = desc;
            Hidden = false;
        }


    }
}