using System;
using System.Collections.Generic;
using System.Linq;
using OctocatAdventures.Models.Location;

namespace OctocatAdventures.Models
{
    public class Game
    {
        public static Player Player { get; private set; } = new Player();


        public static void StartScreen()
        {
            
            string s = "Welcome to the game!!!";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.WriteLine("press enter to start");
            string throwaway = Console.ReadLine();


        }


        public static void Main(string[] args)
        {
            bool running = true;

            StartScreen();
            Player.Location = Place.SouthCourts;
            string Input = "";
            while (running)
            {
                Console.Clear();
                Console.WriteLine("::"+Input);
                Player.Perception();
                Console.WriteLine("");
                Console.WriteLine("What will you do?\n");
                Input =Console.ReadLine();

                Inputhandler.HandleInput(Input);
            }

        }
        


    }
}