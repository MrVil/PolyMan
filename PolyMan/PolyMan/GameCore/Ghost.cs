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
    public class Ghost: SpriteDynamic
    {
        private byte idGhost;
        private static byte nbGhost = 0;
        Texture2D fear0, fear1;

        public Ghost() : base()
        {
            idGhost = nbGhost;
            nbGhost++;

            switch (idGhost)
            {
                case 0: Position = Maze.convertMatrixToPix(new Vector2(13, 14)); break;
                case 1: Position = Maze.convertMatrixToPix(new Vector2(14, 14)); break; 
                case 2: Position = Maze.convertMatrixToPix(new Vector2(13, 15)); break;
                case 3: Position = Maze.convertMatrixToPix(new Vector2(14, 15)); break;
                default: Console.WriteLine("Error, too much ghost"); break;
            }

            
        }

        public override void Initialize(){
            /*for (int i = 0; i < Maze.Height; i++)
                for (int j = 0; j < Maze.Width; j++)
                    if(Maze.Array[])*/
        }

        public override void LoadContent(ContentManager content)
        {
            switch (idGhost)
            {
                case 0: LoadContent(content, "img/fantomeBleu"); break;
                case 1: LoadContent(content, "img/fantomeRose"); break;
                case 2: LoadContent(content, "img/fantomeVert"); break;
                case 3: LoadContent(content, "img/fantomeRouge"); break;
                default: Console.WriteLine("Error, too much ghost"); break;
            }

            fear0 = content.Load<Texture2D>("img/FantomePeur0");
            fear1 = content.Load<Texture2D>("img/FantomePeur1");

        }

    }
}
