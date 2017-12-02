using System;
using System.Collections.Generic;

namespace OctocatAdventures.Models.Location
{
    public class GameMap
    {
        public static Place[,] Map { get; private set; } = new Place[5, 6];

        public static Dictionary<string, Place> PlaceDict = new Dictionary<string, Place>()                 //places are in lower case for validation
        {
            {"square1", Place.Square1},
            {"square2", Place.Square2},
            {"square3", Place.Square3},
            {"square4", Place.Square4 },
            {"square5", Place.Square5},
            {"lakesidetheater",Place.LakesideTheater },
            {"healthcentre", Place.HealthCentre },
            {"northtowers", Place.NorthTowers },
            {"ltb", Place.LTB },
            {"southcourts", Place.SouthCourts },
            {"southtowers",Place.SouthTowers },
            {"gym",Place.Gym }
        
               
        };

        public GameMap()
        {
            Map[0, 0] = Place.Empty;
            Map[0, 1] = Place.Empty;
            Map[0, 2] = Place.HealthCentre;
            Map[0, 3] = Place.NorthTowers;
            Map[0, 4] = Place.Empty;
            Map[0, 5] = Place.Empty;
            Map[1, 0] = Place.Square1;
            Map[1, 1] = Place.Square2;
            Map[1, 2] = Place.Square3;
            Map[1, 3] = Place.Square4;
            Map[1, 4] = Place.Square5;
            Map[1, 5] = Place.LakesideTheater;
            Map[2, 0] = Place.Empty;
            Map[2, 1] = Place.Empty;
            Map[2, 2] = Place.LTB;
            Map[2, 3] = Place.Empty;
            Map[2, 4] = Place.Empty;
            Map[2, 5] = Place.Empty;
            Map[3, 0] = Place.Empty;
            Map[3, 1] = Place.Empty;
            Map[3, 2] = Place.SouthTowers;
            Map[3, 3] = Place.Empty;
            Map[3, 4] = Place.Empty;
            Map[3, 5] = Place.Empty;
            Map[4, 0] = Place.Empty;
            Map[4, 1] = Place.Empty;
            Map[4, 2] = Place.SouthCourts;
            Map[4, 3] = Place.Gym;
            Map[4, 4] = Place.Empty;
            Map[4, 5] = Place.Empty;



        }

        public static Place[] ValidMoves(Place place)
        {
            int Xcoord =0, Ycoord=0;
            bool LookNorth =true, LookEast =true, LookSouth =true, LookWest = true;
            Place North, East, South, West;

            int y = 0, x = 0;
            y = 0;

            while (y < 5)
            {
                x = 0;
                while (x < 6)
                {
                    if (place == Map[y, x])
                    {
                        //System.Diagnostics.Debug.Write("You are in", Map[x,y]);
                        Xcoord = x;
                        Ycoord = y;

                    }
                    x = x + 1;
                }


                y = y + 1;

            }



            x = x - 1; //x is incremented too high by the loop

            y = Xcoord;
            x = Ycoord;

            if (x - 1 < 0)
            {
                LookNorth = false;
            }

            if (LookNorth)
            {
                North = Map[x - 1, y];
            }
            else
            {
                North = Place.Empty;
            }




            if (y + 1 > 5)
            {
                LookEast = false;
            }

            if (LookEast)
            {
                East = Map[x, y + 1];

            }
            else
            {
                East = Place.Empty;
                
            }



            if (x + 1 > 4)
            {
                LookSouth = false;
            }
            if (LookSouth)
            {
                South = Map[x + 1, y];
            }
            else
            {
                South = Place.Empty;

            }


            if (y - 1 < 0)
            {
                LookWest = false;
            }
            if (LookWest)
            {
                West = Map[x, y - 1];
            }
            else
            {
                West = Place.Empty;
                
            }


            
            

            Place[] ValidPlaces = new Place[4];
            ValidPlaces[0] = North;
            ValidPlaces[1] = East;
            ValidPlaces[2] = South;
            ValidPlaces[3] = West;

            return ValidPlaces;



        }
    }
}