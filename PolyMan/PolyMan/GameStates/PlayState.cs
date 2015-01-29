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
        public static Maze maze;
        public Pacman pacman;
        private SpriteFont _pixelFont;

        PlayState(GraphicsDeviceManager graphics)
        {
            _spriteBatch = null;
            _graphics = graphics;
            _nextGameState = this;
            instance = this;
            maze = new Maze();
            pacman = new Pacman();
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
            pacman.Initialize();
        }

        public override void LoadContent(ContentManager content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _nextGameState = instance;
            _pixelFont = content.Load<SpriteFont>("font/pixel");
            maze.LoadContent(content);
            pacman.LoadContent(content);
        }

        public override void UnloadContent()
        {
            instance = null;
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState, GameProperties gameProperties)
        {
            if (keyboardState.IsKeyDown(Keys.Back))
                _nextGameState = MenuState.getInstance(_graphics);

            pacman.Update(gameTime, keyboardState, gameProperties);
        }

        public override void Draw(GameTime gameTime, GameProperties gameProperties)
        {
            maze.Draw(_spriteBatch, gameTime);
            pacman.Draw(_spriteBatch, gameTime);
            string score = gameProperties.Score.ToString();
            _spriteBatch.DrawString(_pixelFont, "Score : "+score, new Vector2(50, 20), Color.White);
        }

        public static Maze getMaze()
        {
            return maze;
        }
    }
}
