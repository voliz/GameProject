using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Objects
{
    public class Projectile : Object, IGameObject
    {
        public Projectile(Texture2D _texture, Vector2 _position, float _speed)
        {
            this.Spritesheet = _texture;
            this.Speed = _speed;
            this.Hitbox = new Rectangle((int)_position.X - 7, (int)_position.Y + 5, _texture.Width, _texture.Height);
        }
        public bool HasHit(Rectangle rect)
        {
            return Hitbox.Intersects(rect);
        }

        public void Update(GameTime gameTime)
        {
            Hitbox.X += (int)Speed;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(this.Spritesheet, this.Hitbox, Color.White);
        }
    }

}
