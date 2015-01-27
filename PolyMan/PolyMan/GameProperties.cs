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

        public GameProperties()
        {
            nbPlayers = 1;
            screenWidth = 800;
            screenHeight = 620;
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
    }
}
