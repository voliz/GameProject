using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Objects.Playable_Characters;
using Microsoft.Xna.Framework;


namespace GameProject.Input
{
    public interface IInputReader
    {
        void ReadInput(Player player, GameTime gameTime);
    }
}
