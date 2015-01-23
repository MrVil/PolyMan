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
        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            if(keyboardState.IsKeyDown(Keys.Up))
            {
                this._velocity = new Vector2 (0, 1);
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                this._velocity = new Vector2(0, -1);
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                this._velocity = new Vector2(-1, 0);
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                this._velocity = new Vector2(1, 0);
            }

            _position += _velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

    }
}
