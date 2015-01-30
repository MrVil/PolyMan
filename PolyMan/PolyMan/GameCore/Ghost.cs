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
using PolyMan.GameStates;
using PolyMan.GameCore.Dijkstra;

namespace PolyMan.GameCore
{
    public class Ghost: SpriteDynamic
    {
        private byte idGhost;
        private static byte nbGhost = 0;
        Texture2D fear0, fear1;
        Sommet[,] sommets;

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

            Maze maze = PlayState.getMaze();
            sommets = new Sommet[maze.Height, maze.Width];
        }

        public override void Initialize(){
            Maze maze = PlayState.getMaze();
            for (int i = 0; i < maze.Height; i++)
                for (int j = 0; j < maze.Width; j++)
                    if (! (maze.Array[i, j] is Wall))
                    {
                        sommets[i,j] = new Sommet(); 
                    }
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

        public override void Update(GameTime gameTime, KeyboardState keyboardState, GameProperties gp)
        {
            Sommet arrive, courant, depart;
            Vector2 currentPos = Maze.convertPixToMatrix(Position);
            Vector2 pacmanPos = Maze.convertPixToMatrix(PlayState.getPacman().Position);
            int y = (int)Math.Floor(pacmanPos.Y);
            int x = (int)Math.Floor(pacmanPos.X);
            arrive = sommets[y, x];
            depart = sommets[(int)Math.Floor(currentPos.Y), (int)Math.Floor(currentPos.X)];
            courant = arrive;
            courant.Potentiel = 0;
            int minimum = 0;
            Maze maze = PlayState.getMaze();

            while (courant != depart)
            {
                Sommet z = courant;
                z.Marque = true;
                try
                {
                    if (sommets[y + 1, x] != null)
                    {
                        Sommet s = sommets[y, x];
                        if (s.Potentiel > z.Potentiel + 1)
                            s.Pred = courant;
                    }
                }
                catch (Exception e)
                {

                }
                minimum = Sommet.INFINI;
            }

            for (int i = 0; i < maze.Height; i++)
                for (int j = 0; j < maze.Width; j++)
                {
                    if (!((sommets[i, j].Marque) || sommets[i, j].Potentiel < minimum))
                    {
                        minimum = sommets[i, j].Potentiel;
                        courant = sommets[i, j];
                    }
                }

            base.Update(gameTime, keyboardState, gp);
        }

    }
}
