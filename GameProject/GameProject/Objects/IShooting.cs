﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Objects
{
    public interface IShooting
    {
        bool CanShoot { get; set; }
        bool IsShooting { get; set; }
    }
}
