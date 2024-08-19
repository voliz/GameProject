using GameProject.Objects.Non_Playable_Characters;
using GameProject.Objects.Playable_Characters;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Movement.MovementTypes
{
    public class PathWayMovement:IEnemyMovement
    {
        public void EnemysMovement(NPC npc, Player player)
        {
            if (!npc.Pathway.Contains(npc.Hitbox))
            {
                npc.Speed = -npc.Speed;
                npc.isFacingRight = !npc.isFacingRight;
            }

            if (!npc.isFacingRight)
            {
                npc.SpriteMoveDirection = SpriteEffects.FlipHorizontally;
            }
            else
            {
                npc.SpriteMoveDirection = SpriteEffects.None;
            }

            npc.Position.X += npc.Speed;
            npc.Hitbox.X = (int)npc.Position.X;
            npc.Hitbox.Y = (int)npc.Position.Y;
        }
    }
}
