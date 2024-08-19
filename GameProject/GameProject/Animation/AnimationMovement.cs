using GameProject.Movement;
using GameProject.Objects;
using GameProject.Objects.Playable_Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Animation
{
    public class AnimationMovement : Animation
    {
        public AnimationMovement(Texture2D spritesheet, float width = 8, float height = 8) : base(spritesheet, width, height) { }

        public void DrawCharacterMovement(Player character, Animation[] _spriteAnimation, SpriteBatch spriteBatch, GameTime gameTime)
        {
            switch (character.CurrentMovementState)
            {
                case CurrentMovementState.RunDown:
                    _spriteAnimation[0].Draw(spriteBatch, character.Position, gameTime, character.SpriteMoveDirection);
                    break;
                case CurrentMovementState.RunUp:
                    _spriteAnimation[1].Draw(spriteBatch, character.Position, gameTime, character.SpriteMoveDirection);
                    break;
                case CurrentMovementState.RunRight:
                    _spriteAnimation[2].Draw(spriteBatch, character.Position, gameTime, character.SpriteMoveDirection);
                    break;
                case CurrentMovementState.ShootDown:
                    _spriteAnimation[3].Draw(spriteBatch, character.Position, gameTime, character.SpriteMoveDirection);
                    break;
                case CurrentMovementState.ShootUp:
                    _spriteAnimation[4].Draw(spriteBatch, character.Position, gameTime, character.SpriteMoveDirection);
                    break;
                case CurrentMovementState.ShootRight:
                    _spriteAnimation[5].Draw(spriteBatch, character.Position, gameTime, character.SpriteMoveDirection);
                    break;
                default:
                    break;
            }
        }
    }
}
