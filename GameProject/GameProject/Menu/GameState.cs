using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Menu
{
    public enum currentGameState { level1, level2, level3, Menu, GameOver }
    public enum currentPlayerState { Win, Lost }
    public interface GameState
    {
        public currentGameState StateOfGame { get; set; }
        public currentPlayerState StateOfPlayer { get; set; }
    }
}
