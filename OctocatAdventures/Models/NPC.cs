using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OctocatAdventures.Models.Location;

namespace OctocatAdventures.Models
{
    public class NPC
    {
        public string Name;
        public string Desc;

        public static Dictionary<Place, NPC> NpcPlaces = new Dictionary<Place, NPC>()                 //places are in lower case for validation
        {
           
            {Place.LTB, new NPC("Steve","he is an asshole") },
            {Place.SouthTowers, new NPC("Kelly", "she has a 30% attendance") },


        };

        public NPC(string name, string desc)
        {
            Name = name;
            Desc = desc;
        }
    }
}
