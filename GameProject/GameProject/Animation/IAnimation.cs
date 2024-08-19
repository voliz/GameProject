using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Animation
{
    public interface IAnimation
    {
        public int Frames { get; set; }
        public int Row { get; set; }
        public int Counter { get; set; }

        void Draw(SpriteBatch spriteBatch, Vector2 position, GameTime gameTime, SpriteEffects spriteEffects, float miliSecPerFrame = 300);
    }
}