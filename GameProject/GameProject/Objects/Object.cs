﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Objects
{
    public class Object
    {
        public Rectangle Hitbox;
        public Vector2 Velocity = new Vector2();
        public Vector2 Position;

        public float Speed { get; set; } = 2;
        public Texture2D Spritesheet { get; set; }
    }
}
