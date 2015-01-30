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
    public abstract class SpriteDynamic : Sprite
    {
        protected Vector2 _velocity;
        protected double timerUpdate;

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public virtual void Initialize()
        {
            timerUpdate = 0;
            base.Initialize();
        }

    }
}
