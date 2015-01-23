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

        public GameStateHandler()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _currentState = MenuState.getInstance(graphics);
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
            _currentState.Update(gameTime, _keyboardState);
            if (_currentState != _currentState.nextGameState()) { 
                _currentState.UnloadContent();
                _currentState = _currentState.nextGameState();
                _currentState.LoadContent(Content, spriteBatch);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            _currentState.Draw(gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
