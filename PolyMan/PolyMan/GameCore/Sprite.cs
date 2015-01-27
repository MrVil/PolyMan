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

namespace PolyMan.GameCore
{
    public abstract class Sprite
    {
        protected Texture2D _texture;
        protected Vector2 _position;

        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public virtual void Initialize()
        {
            _position = Vector2.Zero;
        }

        public virtual void LoadContent(ContentManager content, string assetName)
        {
            _texture = content.Load<Texture2D>(assetName);
        }

        public abstract void LoadContent(ContentManager content);

        public virtual void Update(GameTime gameTime, KeyboardState keyboardState, GameProperties gp)
        {

        }


        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }

    }
}
