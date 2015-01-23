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

namespace PolyMan.GameStates
{
    public class MenuState : GameState
    {
        static MenuState instance;
        private SpriteFont _pixelFont;

        MenuState(GraphicsDeviceManager graphics)
        {
            _spriteBatch = null;
            _graphics = graphics;
            _nextGameState = this;
            instance = this;
        }

        public static GameState getInstance(GraphicsDeviceManager graphics)
        {
            if (instance == null)
                instance = new MenuState(graphics);
            return instance;
        }

        public override void Initialize()
        {

        }

        public override void LoadContent(ContentManager content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _pixelFont = content.Load<SpriteFont>("Pixel");
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                _nextGameState = PlayState.getInstance(_graphics);
            }
                

        }

        public override void Draw(GameTime gameTime)
        {
           if(_spriteBatch != null)
                _spriteBatch.DrawString(_pixelFont, "MenuState", new Vector2(0, 0), Color.White);
        }

        public override GameState nextGameState()
        {
            return _nextGameState;
        }
    }
}
