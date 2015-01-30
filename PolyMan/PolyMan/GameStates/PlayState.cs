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
        public static List<SpriteDynamic> entities;
        private SpriteFont _pixelFont;
        private double timerBonus = 0;
        ContentManager _content;
        private Song _music;
        private KeyboardState oldKbState;

        PlayState(GraphicsDeviceManager graphics)
        {
            _spriteBatch = null;
            _graphics = graphics;
            _nextGameState = this;
            instance = this;
            maze = new Maze();
            entities = new List<SpriteDynamic>();
            entities.Add(new Pacman());
            for (int i = 0; i < 4; i++)
                entities.Add(new Ghost());
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
            foreach(SpriteDynamic sd in entities)
                sd.Initialize();
        }

        public override void LoadContent(ContentManager content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _nextGameState = instance;
            _content = content;
            _pixelFont = content.Load<SpriteFont>("font/pixel");
            _music = content.Load<Song>("sound/DJ Okawari - Flower Dance - 2010"); 
            maze.LoadContent(content);
            foreach (SpriteDynamic sd in entities)
                sd.LoadContent(content);

            MediaPlayer.Play(_music);
        }

        public override void UnloadContent()
        {
            instance = null;
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState, GameProperties gameProperties)
        {
            Pacman pacman = (Pacman)entities[0];
            Console.WriteLine(pacman.NbPeasEat);
            if (pacman.NbPeasEat >= 50)
                _nextGameState = WinState.getInstance(_graphics);

            if (keyboardState.IsKeyDown(Keys.Space)&& oldKbState.IsKeyUp(Keys.Space))
            {
                _nextGameState = PauseState.getInstance(_graphics);
            }

            foreach (SpriteDynamic sd in entities)
                sd.Update(gameTime, keyboardState, gameProperties);

            if (timerBonus >= 0) 
                timerBonus += gameTime.ElapsedGameTime.TotalSeconds;
            

            if (timerBonus > 4.0)
            {
                Food orange = new Food();
                orange.LoadContent(_content);
                maze.Array[13, 17] = orange;
                orange.Position = Maze.convertMatrixToPix(new Vector2(13, 17));
            }

            foreach (SpriteDynamic sd in entities)
                sd.Update(gameTime, keyboardState, gameProperties);

            oldKbState = keyboardState;
        }

        public override void Draw(GameTime gameTime, GameProperties gameProperties)
        {
            maze.Draw(_spriteBatch, gameTime);
            foreach (SpriteDynamic sd in entities)
                sd.Draw(_spriteBatch, gameTime);

            string score = gameProperties.Score.ToString();
            _spriteBatch.DrawString(_pixelFont, "Score : "+score, new Vector2(50, 20), Color.White);
        }

        public static Maze getMaze()
        {
            return maze;
        }

        public static Pacman getPacman()
        {
            return (Pacman)entities[0];
        }

        public static List<SpriteDynamic> getEntities()
        {
            return entities;
        }
    }
}
