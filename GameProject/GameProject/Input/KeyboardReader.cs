using GameProject.Movement;
using GameProject.Objects.Playable_Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Input
{
    public class KeyboardReader : IInputReader
    {
        public void ReadInput(Player player, GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Vector2 Velocity = player.Velocity;


            if (keyboardState.IsKeyDown(Keys.Left)) {
                Velocity.X -= player.Speed;
                player.SpriteMoveDirection = SpriteEffects.FlipHorizontally;
                player.CurrentMovementState = CurrentMovementState.RunRight;
            }
            if (keyboardState.IsKeyDown(Keys.Right)) {
                Velocity.X += player.Speed;
                player.CurrentMovementState = CurrentMovementState.RunRight;
                player.SpriteMoveDirection = SpriteEffects.None;
            };

            if (keyboardState.IsKeyDown(Keys.Down)) {
                Velocity.Y += player.Speed;
                player.CurrentMovementState = CurrentMovementState.RunDown;
            };
            if (keyboardState.IsKeyDown(Keys.Up)) {
                Velocity.Y -= player.Speed;
                player.CurrentMovementState = CurrentMovementState.RunUp;
            };
            if (keyboardState.IsKeyDown(Keys.Space)) 
            {
                player.IsShooting = true;
                player.CanShoot = true;
                if (player.CurrentMovementState == CurrentMovementState.RunUp)
                {
                    player.CurrentMovementState = CurrentMovementState.ShootUp;
                }
                else if (player.CurrentMovementState == CurrentMovementState.RunDown)
                {
                    player.CurrentMovementState = CurrentMovementState.ShootDown;
                }
                else if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.Right))
                {
                    if (keyboardState.IsKeyDown(Keys.Left))
                    {
                        player.SpriteMoveDirection = SpriteEffects.FlipHorizontally;
                        player.CurrentMovementState = CurrentMovementState.ShootRight;
                    }
                    else
                    {
                        player.CurrentMovementState = CurrentMovementState.ShootRight;
                        player.SpriteMoveDirection = SpriteEffects.None;
                    }
                }
            }
            else
            {
                player.IsShooting = false;
            }

            player.Position = Velocity + player.Position;
            player.Hitbox.X = (int)player.Position.X;
            player.Hitbox.Y = (int)player.Position.Y;
        }
    }
}
