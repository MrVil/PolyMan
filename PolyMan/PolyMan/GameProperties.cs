using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolyMan
{
    public class GameProperties
    {
        byte nbPlayers;
        uint screenWidth, screenHeight;
        uint gameAreaWidth, gameAreaHeight;
        uint score;

        public GameProperties()
        {
            nbPlayers = 1;
            screenWidth = 800;
            screenHeight = 620;
            gameAreaWidth = 28*20; //nbColumn * sprite width
            gameAreaHeight = 31*20; //nbLine * sprite height
            score = 0;
        }

        public byte NbPlayers
        {
            set { nbPlayers = value; }
            get { return nbPlayers ; }
        }

        public uint ScreenWidth
        {
            set { screenWidth = value; }
            get { return screenWidth; }
        }
        public uint ScreenHeight
        {
            set { screenHeight = value; }
            get { return screenHeight; }
        }

        public uint GameAreaWidth
        {
            set { gameAreaWidth = value; }
            get { return gameAreaWidth; }
        }
        public uint GameAreaHeight
        {
            set { gameAreaHeight = value; }
            get { return gameAreaHeight; }
        }

        public uint Score
        {
            set { score = value; }
            get { return score; }
        }
    }
}
