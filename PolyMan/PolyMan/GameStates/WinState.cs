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
using PolyMan.GameCore;

namespace PolyMan.GameStates
{
    class WinState : GameState
    {
        static WinState instance;
        private SpriteFont _pixelFont;
        private string pressEnterString = "You win ! \n Press back to return to main menu !";
        Vector2 pressEnterSize;
        Vector2 pressEnterCenter;
        Vector2 pressEnterPosition;
        ContentManager _content;

        WinState(GraphicsDeviceManager graphics)
        {
            _spriteBatch = null;
            _graphics = graphics;
            _nextGameState = this;
            instance = this;
        }

        public static GameState getInstance(GraphicsDeviceManager graphics)
        {
            if (instance == null)
                instance = new WinState(graphics);
            return instance;
        }

        public override void Initialize()
        {
 
        }

        public override void LoadContent(ContentManager content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _nextGameState = instance;
            _content = content;

            _pixelFont = content.Load<SpriteFont>("font/pixel");

            pressEnterSize = _pixelFont.MeasureString(pressEnterString);
            pressEnterCenter = new Vector2(pressEnterSize.X / 2, pressEnterSize.Y / 2);

            //MediaPlayer.Play(_music);
        }

        public override void UnloadContent()
        {
 
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState, GameProperties gameProperties)
        {
            if (keyboardState.IsKeyDown(Keys.Back))
            {
                _nextGameState = MenuState.getInstance(_graphics);
            }

        }

        public override void Draw(GameTime gameTime, GameProperties gameProperties)
        {
            pressEnterPosition = new Vector2(gameProperties.ScreenWidth / 2 - pressEnterCenter.X, gameProperties.ScreenHeight / 2 - pressEnterCenter.Y);
            if (_spriteBatch != null)
                _spriteBatch.DrawString(_pixelFont, pressEnterString, pressEnterPosition, Color.White);
        }

    }
}
