using System;
using System.Collections.Generic;
using System.Linq;

using OctocatAdventures.Models.Location;

namespace OctocatAdventures.Models
{
    public class Player
    {
        public string Name { get; private set; }

        public Place Location { get; set; }

        public int Health { get; private set; }

        public int Money { get; private set; }

        public Inventory Inventory { get; private set; }

        public int ChangeMoney (int amount)
        {
            this.Money += amount;
            return this.Money;
        }

        public int ChangeHealth (int amount)
        {
            this.Health += amount;
            return this.Health;
        }



        public bool Move(string location)
        {
            foreach (var p in GameMap.PlaceDict.Keys)                                   //if place in the list of places
            {
                if (location.ToLower().Contains(p))
                {
                    location = p;
                    break;
                }
            
            }

            var place = GameMap.PlaceDict[location];
            if (GameMap.ValidMoves(this.Location).Any(p => p == place))                 //if place entered is a valid move from current location
            {
                this.Location = place;
                return true;
            }

            return false;


        }


    }
}