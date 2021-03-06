﻿using System;
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

namespace PolyMan.GameCore
{
    public class Pacman: SpriteDynamic
    {
        Texture2D _textureRight, _textureLeft,_textureDown, _textureUp;
        Texture2D _textureRight2, _textureLeft2, _textureDown2, _textureUp2;
        Texture2D _textureDead, _textureDead2, _textureDead3, _textureDead4;

        SoundEffect _peasEat1, _peasEat2, _currentSE;

        double timerAnimation = 0;
        int nbPeasEat;
        int _speed = 10;

        public Pacman()
            : base()
        {
            Position = Maze.convertMatrixToPix(new Vector2(14, 23));
            nbPeasEat = 0;
            Velocity = new Vector2(-1, 0);
        }

        public int NbPeasEat
        {
            get { return nbPeasEat; }
            set { nbPeasEat = value;}
        }

        public override void LoadContent(ContentManager content)
        {

            _textureRight = content.Load<Texture2D>("img/pacman");
            _textureLeft = content.Load<Texture2D>("img/pacman_2");
            _textureDown = content.Load<Texture2D>("img/pacman_3");            
            _textureUp = content.Load<Texture2D>("img/pacman_4");

            _textureRight2 = content.Load<Texture2D>("img/pacman_f");
            _textureLeft2 = content.Load<Texture2D>("img/pacman_2f");
            _textureDown2 = content.Load<Texture2D>("img/pacman_3f");
            _textureUp2 = content.Load<Texture2D>("img/pacman_4f");
           
            _textureDead = content.Load<Texture2D>("img/Mort0");
            _textureDead2 = content.Load<Texture2D>("img/Mort1");
            _textureDead3 = content.Load<Texture2D>("img/Mort2");
            _textureDead4 = content.Load<Texture2D>("img/Mort3");

            _peasEat1 = content.Load<SoundEffect>("sound/PelletEat1");
            _peasEat2 = content.Load<SoundEffect>("sound/PelletEat2");

            _currentSE = _peasEat1;

            SoundEffectInstance inst1 = _peasEat1.CreateInstance();
            SoundEffectInstance inst2 = _peasEat2.CreateInstance();
            SoundEffectInstance inst3 = _currentSE.CreateInstance();
            inst1.Volume = 0;
            inst2.Volume = 0;
            inst3.Volume = 0;


            Texture = _textureLeft;
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState, GameProperties gp)
        {
            timerUpdate += gameTime.ElapsedGameTime.TotalMilliseconds;
            timerAnimation += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timerUpdate < _speed)
                return;

            Velocity = nextStepVelocity(gameTime, keyboardState, gp);

            if (timerAnimation > 200)
            {
                if (_texture == _textureDown)
                    _texture = _textureDown2;
                else if (_texture == _textureDown2)
                    _texture = _textureDown;
                else if (_texture == _textureUp)
                    _texture = _textureUp2;
                else if (_texture == _textureUp2)
                    _texture = _textureUp;
                else if (_texture == _textureLeft)                
                    _texture = _textureLeft2;
                else if (_texture == _textureLeft2)
                    _texture = _textureLeft;
                else if (_texture == _textureRight)
                    _texture = _textureRight2;
                else if (_texture == _textureRight2)
                    _texture = _textureRight;
                timerAnimation = 0;
               
            }

            _position = Vector2.Add(_position, _velocity);
            _position.X = Maze.xmargin + (_position.X+gp.GameAreaWidth - Maze.xmargin) % (gp.GameAreaWidth);
            _position.Y = (_position.Y+gp.GameAreaHeight) % gp.GameAreaHeight;

            timerUpdate = 0;
        }

        public Vector2 nextStepVelocity(GameTime gameTime, KeyboardState keyboardState, GameProperties gp)
        {
            Vector2 velocity = _velocity;
            Vector2 position = _position;
            Vector2 positionMaze = Maze.convertPixToMatrix(position);
            Maze maze = PlayState.getMaze();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                velocity = new Vector2(0, -1);
                _texture = _textureUp;                                                                             
            }


            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                velocity = new Vector2(0, 1);
                _texture = _textureDown;
            }

            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                velocity = new Vector2(-1, 0);
                _texture = _textureLeft;
            }

            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                velocity = new Vector2(1, 0);
                _texture = _textureRight;
            }

            position = Vector2.Add(position, velocity);
            positionMaze = Maze.convertPixToMatrix(position);

            if(velocity.X == -1){
                positionMaze.X = (float)Math.Floor(positionMaze.X);
            }
            else if (velocity.X == 1){
                positionMaze.X = (float)Math.Ceiling(positionMaze.X);
            }
            else
                positionMaze.X = (float)Math.Round(positionMaze.X);
            
            if(velocity.Y == -1){
                positionMaze.Y = (float)Math.Floor(positionMaze.Y);
            }
            else if (velocity.Y == 1) { 
                positionMaze.Y = (float)Math.Ceiling(positionMaze.Y);
            }
            else
                positionMaze.Y = (float)Math.Round(positionMaze.Y);

            try {
                if (maze.Array[(int)positionMaze.Y, (int)positionMaze.X] is Wall || maze.Array[(int)positionMaze.Y, (int)positionMaze.X] is Gate)
                {
                    velocity = Vector2.Zero;
                }
                else if (maze.Array[(int)positionMaze.Y, (int)positionMaze.X] is Peas)
                {
                    gp.Score += 60;
                    nbPeasEat++;
                    maze.Array[(int)positionMaze.Y, (int)positionMaze.X] = new Empty();
                    _currentSE.Play();
                    _currentSE = (_currentSE == _peasEat2) ? _peasEat1 : _peasEat2;
                    _speed = 50;
                }

                else if (maze.Array[(int)positionMaze.Y, (int)positionMaze.X] is SuperPeas)
                {
                    gp.Score += 60;
                    nbPeasEat++;
                    maze.Array[(int)positionMaze.Y, (int)positionMaze.X] = new Empty();
                    _currentSE.Play();
                    _currentSE = (_currentSE == _peasEat2) ? _peasEat1 : _peasEat2;
                    _speed = 50;
                }

                else if (maze.Array[(int)positionMaze.Y, (int)positionMaze.X] is Food)
                {
                    gp.Score += 100;
                    nbPeasEat++;
                    maze.Array[(int)positionMaze.Y, (int)positionMaze.X] = new Empty();
                    _currentSE.Play();
                    _currentSE = (_currentSE == _peasEat2) ? _peasEat1 : _peasEat2;
                }

                else
                    _speed = 10;

            }
            catch(Exception e){

            }

            return velocity;
        }
    }
}
