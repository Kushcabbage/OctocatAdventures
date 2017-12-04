using System;
using System.Collections.Generic;
using System.Linq;

namespace OctocatAdventures.Models
{
    public class Inputhandler
    {
        static Dictionary<string, Func<string, bool>> ActionDict = new Dictionary<string, Func<string, bool>>()
        {
            {"move", Game.Player.Move},
            {"take", Game.Player.Take},
            {"inventory", Game.Player.ShowInventory }
        };
        public static void HandleInput(string playerinput)
        {

            if (!string.IsNullOrEmpty(playerinput) && ActionDict.ContainsKey(playerinput.Split()[0]))
            {

                ActionDict[playerinput.ToLower().Split()[0]](playerinput);
            }
            else
            {
                Console.WriteLine("There is a time and place for that!");
            }


        }





    }
}