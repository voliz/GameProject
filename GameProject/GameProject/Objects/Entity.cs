using GameProject.Movement;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Objects
{
    public abstract class Entity : Object, IMovable
    {
        //IMovable
        public SpriteEffects SpriteMoveDirection { get; set; }
        public CurrentMovementState CurrentMovementState { get; set; }

        public float StartY { get; set; }
        public bool CanShoot { get; set; } = false;
        public bool IsShooting { get; set; }
        //Condition
        public bool IsAlive { get; set; } = true;

    }
}
