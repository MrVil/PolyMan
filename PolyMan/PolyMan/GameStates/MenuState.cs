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
            _nextGameState = instance;

            _pixelFont = content.Load<SpriteFont>("Pixel");
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState, GameProperties gameProperties)
        {
            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                _nextGameState = PlayState.getInstance(_graphics);
            }
                

        }

        public override void Draw(GameTime gameTime, GameProperties gameProperties)
        {

            Vector2 stringPos = new Vector2(gameProperties.ScreenWidth/2, gameProperties.ScreenHeight/2);
           if(_spriteBatch != null)
                _spriteBatch.DrawString(_pixelFont, "Press Enter to play", stringPos, Color.White);
        }
    }
}
