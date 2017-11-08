using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    class TechZombie : Actors
    {

        int damage;

        public TechZombie(float speed, int health, PointF startPosition, Graphics sprite, int damage)
        {

        }

        public override void Update(float fps)
        {

        }

        public override void Movement()
        {
            
        }

        public override void Collide()
        {
            base.Collide();
        }

        public override void Gravity()
        {
            base.Gravity();
        }
    }
}
