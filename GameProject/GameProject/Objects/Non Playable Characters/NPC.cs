using GameProject.Movement.MovementTypes;
using GameProject.Objects.Playable_Characters;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Objects.Non_Playable_Characters
{
    public class NPC : Entity
    {
        public bool IsInteligent;
        public bool isFacingRight = true;

        public Rectangle Pathway;

        public Player Player;
        public PathWayMovement PathWayMovement = new PathWayMovement();
        public FollowingMovement FollowingMovement = new FollowingMovement();
    }
}
