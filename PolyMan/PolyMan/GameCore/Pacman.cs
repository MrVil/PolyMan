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
    class Pacman: SpriteDynamic
    {
        Texture2D _textureRight, _textureLeft,_textureDown, _textureUp;
        Texture2D _textureRight2, _textureLeft2, _textureDown2, _textureUp2;
        double timerAnimation = 0;

        public override void LoadContent(ContentManager content)
        {
            _textureRight = content.Load<Texture2D>("img/pacman");
            _textureLeft = content.Load<Texture2D>("img/pacman_2");
            _textureDown = content.Load<Texture2D>("img/pacman_3");            
            _textureUp = content.Load<Texture2D>("img/pacman_4");

            _textureRight2 = content.Load<Texture2D>("img/pacman_f");
            _textureLeft2 = content.Load<Texture2D>("img/pacman_2f");
            _textureDown2 = content.Load<Texture2D>("img/pacman_3f");
            _textureUp2 = content.Load<Texture2D>("img/pacman_4f");
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState, GameProperties gp)
        {
            timerUpdate += gameTime.ElapsedGameTime.TotalMilliseconds;
            timerAnimation += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timerUpdate < 10)
                return;

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                this._velocity = new Vector2(0, -1);
                _texture = _textureUp;
            }


            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                this._velocity = new Vector2(0, 1);
                _texture = _textureDown;
            }

            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                this._velocity = new Vector2(-1, 0);
                _texture = _textureLeft;
            }

            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                this._velocity = new Vector2(1, 0);
                _texture = _textureRight;
            }

            else if (timerAnimation > 100)
            {
                if (_texture == _textureDown)
                    _texture = _textureDown2;
                else if (_texture == _textureDown2)
                    _texture = _textureDown;
                else if (_texture == _textureUp)
                    _texture = _textureUp2;
                else if (_texture == _textureUp2)
                    _texture = _textureUp;
                else if (_texture == _textureLeft)
                    _texture = _textureLeft2;
                else if (_texture == _textureLeft2)
                    _texture = _textureLeft;
                else if (_texture == _textureRight)
                    _texture = _textureRight2;
                else if (_texture == _textureRight2)
                    _texture = _textureRight;
                timerAnimation = 0;
               
            }

            _position = Vector2.Add(_position, _velocity);
            _position.X = (_position.X+gp.ScreenWidth) % gp.ScreenWidth;
            _position.Y = (_position.Y+gp.ScreenHeight) % gp.ScreenHeight;
        }

    }
}
