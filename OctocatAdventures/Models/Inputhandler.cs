using System;
using System.Collections.Generic;
using System.Linq;

namespace OctocatAdventures.Models
{
    public class Inputhandler
    {
        Dictionary<string, Func<string, bool>> ActionDict = new Dictionary<string, Func<string, bool>>()
        {
            {"Move", Game.Player.Move}
        };
        void HandleInput(string playerinput)
        {

            if (string.IsNullOrEmpty(playerinput))
            {
                ActionDict[playerinput.ToLower().Split()[0]](playerinput);
            }



        }





    }
}