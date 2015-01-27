using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PolyMan.GameCore
{
    class Ghost: SpriteDynamic
    {
        private static byte nbGhost = 0;
        Texture2D fear0, fear1;

        Ghost() : base()
        {
            nbGhost++;
        }

        public override void LoadContent(ContentManager content)
        {
            switch (nbGhost)
            {
                case 0: LoadContent(content, "img/fantomeBleu"); break;
                case 1: LoadContent(content, "img/fantomeBleu"); break;
                case 2: LoadContent(content, "img/fantomeBleu"); break;
                case 3: LoadContent(content, "img/fantomeBleu"); break;
                default: Console.WriteLine("Error, too much ghost"); break;
            }

            fear0 = content.Load<Texture2D>("img/FantomePeur0");
            fear1 = content.Load<Texture2D>("img/FantomePeur1");

        }
    }
}
