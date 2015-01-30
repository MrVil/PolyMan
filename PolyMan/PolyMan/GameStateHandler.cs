using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PolyMan.GameStates;


namespace PolyMan
{
    public class GameStateHandler : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState _currentState;
        KeyboardState _keyboardState;
        GameProperties _gameProperties;

        public GameStateHandler()
        {
            graphics = new GraphicsDeviceManager(this);
            _currentState = MenuState.getInstance(graphics);
            _gameProperties = new GameProperties();
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = (int)_gameProperties.ScreenWidth;
            graphics.PreferredBackBufferHeight = (int)_gameProperties.ScreenHeight;

            graphics.SynchronizeWithVerticalRetrace = false;
        	IsFixedTimeStep = false;

        }

        protected override void Initialize()
        {
            _currentState.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentState.LoadContent(Content, spriteBatch);
        }

        protected override void UnloadContent()
        {
            _currentState.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            _keyboardState = Keyboard.GetState();
            _currentState.Update(gameTime, _keyboardState, _gameProperties);
            if (_currentState != _currentState.NextGameState) { 
                _currentState = _currentState.NextGameState;
                _currentState.LoadContent(Content, spriteBatch);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            _currentState.Draw(gameTime, _gameProperties);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
