using System;
using System.Collections.Generic;
using System.IO;

namespace OctocatAdventures.Models.Location
{
    public static class GameMap
    {
        public static Place[,] Map { get; private set; } = new Place[5, 6]
        {
            { Place.Empty, Place.Empty, Place.HealthCentre, Place.NorthTowers, Place.Empty, Place.Empty },
            { Place.Square1, Place.Square2, Place.Square3, Place.Square4, Place.Square5, Place.LakesideTheater },
            { Place.Empty, Place.Empty, Place.LTB, Place.Empty, Place.Empty, Place.Empty },
            { Place.Empty, Place.Empty,  Place.SouthTowers, Place.Empty, Place.Empty, Place.Empty },
            { Place.Empty, Place.Empty, Place.SouthCourts, Place.Gym, Place.Empty, Place.Empty }
        };

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

        public static Place[] ValidMoves(Place place)
        {
            int placeX = 0;
            int placeY = 0;

            for (int y = 0; y <= Map.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= Map.GetUpperBound(1); x++)
                {
                    if (Map[y, x] == place)
                    {
                        placeX = x;
                        placeY = y;
                    }
                }
            }
            
            var dirs = new int[][] { new[] { -1, 0 }, new[] { 0, 1 }, new [] {1, 0}, new []{0, -1} };

            List<Place> validPlaces = new List<Place>();

            foreach (var dir in dirs)
            {
                int tmpPlaceX = placeX + dir[1];
                int tmpPlaceY = placeY + dir[0];
                if (tmpPlaceY < 0 || tmpPlaceY > Map.GetUpperBound(0) ||
                    tmpPlaceX < 0 || tmpPlaceX > Map.GetUpperBound(1))
                {
                    validPlaces.Add(Place.Empty);
                }

                else
                {
                    validPlaces.Add(Map[tmpPlaceY, tmpPlaceX]);
                }
            }

            return validPlaces.ToArray();
        }
    }
}