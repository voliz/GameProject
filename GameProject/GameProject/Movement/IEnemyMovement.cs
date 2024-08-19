using GameProject.Objects.Non_Playable_Characters;
using GameProject.Objects.Playable_Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Movement
{
    public interface IEnemyMovement
    {
        public void EnemysMovement(NPC npc, Player player = null);
    }
}
