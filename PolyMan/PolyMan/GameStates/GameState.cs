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
    public abstract class GameState
    {
        public SpriteBatch _spriteBatch;
        public GraphicsDeviceManager _graphics;
        public GameState _nextGameState;

        public abstract void Initialize();

        public abstract void LoadContent(ContentManager content, SpriteBatch spriteBatch);

        public abstract void UnloadContent();

        public abstract void Update(GameTime gameTime, KeyboardState keyboardState);

        public abstract void Draw(GameTime gameTime);

        public abstract GameState nextGameState();
    }
}
