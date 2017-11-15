using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piperlok.Interfaces;
using Piperlok.FPowerUps;

namespace Piperlok.GameObejcts
{
    class ColaMachine : Objects , Ipower
    {
        private int ColasSpawned;
        public ColaMachine(bool moveable, bool collideable, string imagePath, bool power, Vector2D position, float scalefactor, bool dangerous, string name, bool destroyable) : base(false, false, imagePath, position, name, scalefactor, false)
        {
        }

        public void PowerOn()
        {
            //throw new NotImplementedException();
        }
        public void SpawnCola()
        {
            if(ColasSpawned <= 0)
            {
                //new Cola(new PointF(10,10)a);
            }
        }
    }
}
