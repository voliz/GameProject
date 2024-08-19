using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Animation
{
    public class Animation : IAnimation
    {
        Texture2D _texture;

        public int Frames { get ; set; }
        public int Row { get; set; }
        public int Counter { get; set; } = 0;
        
        float TslFrame = 0; //Time since last frame

        public Animation(Texture2D spritesheet, float width = 8, float height = 8)
        {
            this._texture = spritesheet;
            Frames = (int)(spritesheet.Width / width);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, GameTime gameTime, SpriteEffects spriteDirection = SpriteEffects.None, float miliSecPerFrame = 300)
        {
            if (Counter < Frames)
            {

                var rect = new Rectangle(8 * Counter, 0, 8, 8);
                spriteBatch.Draw(_texture, position, rect, Color.White, 0f, new Vector2(), 5f, spriteDirection, 0f);
                TslFrame += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (TslFrame > miliSecPerFrame)
                {
                    TslFrame -= miliSecPerFrame;
                    Counter++;
                    if (Counter == Frames)
                    {
                        Counter = 0;
                    }
                }
            }
        }
    }
}
