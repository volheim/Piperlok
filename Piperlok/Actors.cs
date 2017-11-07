using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    abstract class Actors
    {

        public bool alive;

        public float speed;
        public int health;

        public string name;

        public PointF position;
        public Graphics sprite;

        public abstract void Update();

        public abstract void Movement();

        public virtual void Collide()
        {

        }

        public virtual void Gravity()
        {

        }

    }
}
