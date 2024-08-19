using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Objects
{
    public class BuffItem : Object, IGameObject
    {
        public BuffItem(Texture2D _buffTexture, Vector2 _position, float _speed)
        {
            this.Spritesheet = _buffTexture;
            this.Speed = _speed;
            this.Hitbox = new Rectangle((int)_position.X, (int)_position.Y, _buffTexture.Width, _buffTexture.Height);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(this.Spritesheet, this.Hitbox, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Hitbox.X += (int)Speed;
        }
    }
}
