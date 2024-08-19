using GameProject.Objects.Non_Playable_Characters;
using GameProject.Objects.Playable_Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Movement.MovementTypes
{
    public class FollowingMovement : IEnemyMovement
    {
        public void EnemysMovement(NPC npc, Player player)
        {
            Vector2 Velocity = npc.Velocity;

            if (player.Position.X > npc.Position.X)
            {
                npc.SpriteMoveDirection = SpriteEffects.None;
                Velocity.X += npc.Speed;

            }
            else if (player.Position.X < npc.Position.X)
            {
                Velocity.X -= npc.Speed;
                npc.SpriteMoveDirection = SpriteEffects.FlipHorizontally;
            }
            else
            {
                npc.SpriteMoveDirection = SpriteEffects.None;
            }


            npc.Position = Velocity + npc.Position;
            npc.Hitbox.X = (int)npc.Position.X;
            npc.Hitbox.Y = (int)npc.Position.Y;

        }
    }
}
