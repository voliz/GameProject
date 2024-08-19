using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Movement
{
    public enum CurrentMovementState
    {
        RunDown,
        RunUp,
        RunRight,
        ShootUp,
        ShootDown,
        ShootRight,
        Idle,
        Running,
    }
    public interface IMovable
    {
        public SpriteEffects SpriteMoveDirection { get; set; }
        public CurrentMovementState CurrentMovementState { get; set; }
    }
}
