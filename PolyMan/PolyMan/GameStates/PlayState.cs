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
using PolyMan.GameCore;

namespace PolyMan.GameStates
{
    public class PlayState : GameState
    {
        static PlayState instance;
        public Maze maze;

        PlayState(GraphicsDeviceManager graphics)
        {
            _spriteBatch = null;
            _graphics = graphics;
            _nextGameState = this;
            instance = this;
            maze = new Maze();
        }

        public static GameState getInstance(GraphicsDeviceManager graphics)
        {
            if (instance == null)
                instance = new PlayState(graphics);
            return instance;
        }

        public override void Initialize()
        {
            _nextGameState = instance;
            maze.Initialize();
        }

        public override void LoadContent(ContentManager content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _nextGameState = instance;
            maze.LoadContent(content);
        }

        public override void UnloadContent()
        {
            instance = null;
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState, GameProperties gameProperties)
        {
            if (keyboardState.IsKeyDown(Keys.Back))
                _nextGameState = MenuState.getInstance(_graphics); 
        }

        public override void Draw(GameTime gameTime, GameProperties gameProperties)
        {
            maze.Draw(_spriteBatch, gameTime);
        }
    }
}
