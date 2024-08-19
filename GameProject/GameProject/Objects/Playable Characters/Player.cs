using GameProject.Movement;
using GameProject.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Input;
using GameProject.Objects.Non_Playable_Characters;

namespace GameProject.Objects.Playable_Characters
{
    public class Player : Entity, IGameObject
    {
        public Animation.Animation[] PlayerAnimation;
        public AnimationMovement AnimationMovement;
        public new CurrentMovementState CurrentMovementState;
        public int Time_x_hurt { get; set; } = 80;
        public int TimeXAttacking { get; set; }
        public int Points { get; set; }
        public int Health = 5;
        public KeyboardReader InputReader { get; set; }
        public bool _touchedBuff;

        public Player(Vector2 _position, Texture2D _spriteRunDown, Texture2D _spriteRunUp, Texture2D _spriteRunRight, Texture2D _spriteShootDown, Texture2D _spriteShootUp, Texture2D _spriteShootRight, bool canshoot = true)
        {
            Spritesheet = _spriteRunRight;
            Position = _position;
            StartY = Velocity.Y;
            InputReader = new KeyboardReader();

            CanShoot = canshoot;
            IsShooting = false;
            _touchedBuff = false;

            PlayerAnimation = new Animation.Animation[8];
            PlayerAnimation[0] = new Animation.Animation(_spriteRunDown);
            PlayerAnimation[1] = new Animation.Animation(_spriteRunUp);
            PlayerAnimation[2] = new Animation.Animation(_spriteRunRight);
            PlayerAnimation[3] = new Animation.Animation(_spriteShootDown);
            PlayerAnimation[4] = new Animation.Animation(_spriteShootUp);
            PlayerAnimation[5] = new Animation.Animation(_spriteShootRight);
            CurrentMovementState = CurrentMovementState.RunRight;
            AnimationMovement = new AnimationMovement(Spritesheet);
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 25, 32);
        }

        public void Update(GameTime gameTime)
        {
            InputReader.ReadInput(this,gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            AnimationMovement.DrawCharacterMovement(this, PlayerAnimation, spriteBatch, gameTime);
        }
        public bool TouchedEnemy(List<Enemy> enemyList)
        {
            foreach (var item in enemyList.ToArray())
            {
                if (this.Hitbox.Intersects(item.Hitbox))
                    return true;
            }
            return false;

        }
    }
}
