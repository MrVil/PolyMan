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
    class Gate : Sprite
    {
        public override void LoadContent(ContentManager content)
        {
            LoadContent(content, "img/barriereFantome");
        }
    }
}
