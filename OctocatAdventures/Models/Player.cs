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

        public Inventory Inventory { get; private set; } = new Inventory();

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
            
            foreach (var p in GameMap.PlaceDict.Keys)                                   ///Look in dictionary of places to get place object of current location
            {
                if (location.ToLower().Contains(p))
                {
                    location = p;
                    break;
                }
            
            }




            if (GameMap.PlaceDict.ContainsKey(location))
            {
                var CurrentPlace = GameMap.PlaceDict[location];

                if (GameMap.ValidMoves(this.Location).Any(p => p == CurrentPlace))                 //if place entered is a valid move from current location
                {
                    this.Location = CurrentPlace;
                    return true;
                }


            }
            else                                                                                    //for uusing directions
            {


                var CurrentPlace = this.Location;
                if (location.ToLower().Contains("north"))
                {
                    this.Location = GameMap.ValidMoves(CurrentPlace)[0];
                    return true;
                }
                if(location.ToLower().Contains("east"))
                {
                    this.Location = GameMap.ValidMoves(CurrentPlace)[1];
                    return true;

                }
                if (location.ToLower().Contains("south"))
                {
                    this.Location = GameMap.ValidMoves(CurrentPlace)[2];
                    return true;

                }
                if (location.ToLower().Contains("west"))
                {
                    this.Location = GameMap.ValidMoves(CurrentPlace)[3];
                    return true;

                }






            }

            Console.Write("You cannot move to this place");
            return false;
        }


        public bool Take(string input)
        {
           
            foreach (var word in input.Split())
            {
                if (Item.ItemPlaces.ContainsKey(word) && Location ==Item.ItemPlaces[word])
                {
                    Inventory.Items.Add(Item.Items.FirstOrDefault(i => i.Name == word));
                    Item.ItemPlaces.Remove(word);
                    Item.Seeitems.Remove(Item.Seeitems.FirstOrDefault(i => i.Value.Name == word).Key);
                    
                    //set item.hidden to true
                    
                    return true;
                }
            }

            return false;
        }

        public bool ShowInventory(string input)
        {
            Console.WriteLine("Inventory:");
            if (Inventory.Items.Count == 0)
            {
                Console.WriteLine("EMPTY");
                return true;
            }
            else
            {
                foreach (var inv in Inventory.Items)
                {
                    Console.WriteLine(inv.Name + ", " + inv.Desc);
                }

                return true;
            }
        }




        public void Perception()
        {
            Console.Write("\nYou are in ");
            Console.Write(Location);
            Console.WriteLine(".");

            if (NPC.NpcPlaces.ContainsKey(Location))
            {

                Console.Write("You see ");
                Console.Write(NPC.NpcPlaces[Location].Name);
                Console.Write(", ");
                Console.Write(NPC.NpcPlaces[Location].Desc);
                Console.WriteLine(".");
            }
            if (Item.Seeitems.ContainsKey(Location))
            {
                Console.Write("You see a ");
                Console.WriteLine(Item.Seeitems[Location].Name);
            }


        }


    }
}