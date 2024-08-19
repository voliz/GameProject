using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Objects
{
    public interface IPlayerConditionCheck
    {
        public bool PlayerIsAlive { get; set; }
        public bool GameIsOver { get; set; }
    }
}
