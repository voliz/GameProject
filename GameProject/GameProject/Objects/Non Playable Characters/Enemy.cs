using GameProject.Animation;
using GameProject.Movement;
using GameProject.Objects.Playable_Characters;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Objects.Non_Playable_Characters
{
    public class Enemy : NPC, IGameObject
    {
        public Animation.Animation[] NPCAnimation;
        public new CurrentMovementState CurrentMovementState;
        public AnimationMovement AnimationMovement;

        public Enemy(Texture2D _enemySpriteSheet, Rectangle _pathway, float speed, bool _isInteligent, Player _player, Vector2 inteligentPosition)
        {
            this.IsInteligent = _isInteligent;

            if (this.IsInteligent)
            {
                this.Position = new Vector2(inteligentPosition.X, inteligentPosition.Y);
                Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 25, 30);

            }
            else
            {
                this.Position = new Vector2(_pathway.X, _pathway.Y);
                Hitbox = new Rectangle((int)this.Position.X, (int)this.Position.Y, 32, 32);

            }

            this.StartY = this.Velocity.Y;
            this.Spritesheet = _enemySpriteSheet;
            this.Pathway = _pathway;
            this.Speed = speed;
            this.isFacingRight = true;
            this.Player = _player;
            this.SpriteMoveDirection = SpriteEffects.None;

            IsShooting = false;


            NPCAnimation = new Animation.Animation[1];
            NPCAnimation[0] = new Animation.Animation(_enemySpriteSheet);

            this.CurrentMovementState = CurrentMovementState.RunRight;
            AnimationMovement = new AnimationMovement(this.Spritesheet);
        }



        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            AnimationMovement.Draw(spriteBatch, this.Position, gameTime, this.SpriteMoveDirection);
        }

        public void Update(GameTime gameTime)
        {
            if (!this.IsInteligent)
                PathWayMovement.EnemysMovement(this, this.Player);
            else
                FollowingMovement.EnemysMovement(this, this.Player);

        }
    }
}
