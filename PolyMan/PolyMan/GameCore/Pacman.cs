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

namespace PolyMan.GameCore
{
    class Pacman: Sprite
    {
        Texture2D _textureRight, _textureLeft,_textureDown, _textureUp;

        public void LoadContent(ContentManager content)
        {
            _textureRight = content.Load<Texture2D>("img/pacman");
            _textureLeft = content.Load<Texture2D>("img/pacman_2");
            _textureDown = content.Load<Texture2D>("img/pacman_3");            
            _textureUp = content.Load<Texture2D>("img/pacman_4");
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {

            time += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (time < 40)
                return;

            time = 0;

            if(keyboardState.IsKeyDown(Keys.Up))
            {
                this._velocity = new Vector2 (0, -1);
                _texture = _textureUp;
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                this._velocity = new Vector2(0, 1);
                _texture = _textureDown;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                this._velocity = new Vector2(-1, 0);
                _texture = _textureLeft;
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                this._velocity = new Vector2(1, 0);
                _texture = _textureRight;
            }

            _position = Vector2.Add(_position, _velocity);
        }

    }
}
