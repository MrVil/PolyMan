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
    class PauseState : GameState
    {
        static PauseState instance;
        public static Maze maze;
        public static List<SpriteDynamic> entities;
        private SpriteFont _pixelFont;
        private double timerBonus = 0;
        ContentManager _content;
        private Song _music;
        private KeyboardState oldKbState;

        PauseState(GraphicsDeviceManager graphics)
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
                instance = new PauseState(graphics);
            return instance;
        }

        public override void Initialize()
        {
            _nextGameState = instance;
            maze = PlayState.getMaze();
            entities = PlayState.getEntities();
            if (entities == null)
                Console.WriteLine("ça chie");
 
        }

        public override void LoadContent(ContentManager content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _nextGameState = instance;
            _content = content;
            _pixelFont = content.Load<SpriteFont>("font/pixel");
        }

        public override void UnloadContent()
        {
            instance = null;
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState, GameProperties gameProperties)
        {
            if (keyboardState.IsKeyDown(Keys.Space)&& oldKbState.IsKeyUp(Keys.Space))
                _nextGameState = PlayState.getInstance(_graphics);

            oldKbState = keyboardState;
        }


        public override void Draw(GameTime gameTime, GameProperties gameProperties)
        {
            maze.Draw(_spriteBatch, gameTime);
            if(entities != null)
                foreach (SpriteDynamic sd in entities)
                    sd.Draw(_spriteBatch, gameTime);

            string score = gameProperties.Score.ToString();
            _spriteBatch.DrawString(_pixelFont, "Score : " + score, new Vector2(50, 20), Color.White);
            string _stringPause = "PAUSE \n Press Spacebar to resume game";
            _spriteBatch.DrawString(_pixelFont, _stringPause, new Vector2(50, 20), Color.White);
        }

    }
}
