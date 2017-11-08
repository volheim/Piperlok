using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Piperlok.Interfaces;

namespace Piperlok
{
    class TechZombie : Actors, IEnemy
    {

        int damage;
        bool Direction = false;

        public TechZombie(float speed, int health, PointF startPosition, Graphics sprite, int damage)
        {

        }

        public override void Update(float fps)
        {

        }

        public override void Movement()
        {
            if (Direction == false)
            {
                position.X -= speed / Form1.currentFps;
            }
            else
            {
                position.X += speed / Form1.currentFps;
            }
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
