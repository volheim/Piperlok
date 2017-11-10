using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok.FPowerUps
{
    abstract class PowerUps
    {
        public bool active;

        //tid i sekunder powerupen er aktiv
        public float duration;

        public PointF position;
    }
}
