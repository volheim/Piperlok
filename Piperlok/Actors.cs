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
        //bruges til at indikere om en actor er aktiv. kameraer som ikke er alive stopper, zombier er ikke længere farlige, piperlok og Milo MacDonald dør
        public bool alive;

        public float speed;
        public int health;

        public string name;

        public PointF position;
        public Graphics sprite;

        public float gravityPull;

        public abstract void Update(float fps);

        public abstract void Movement();

        public virtual void Collide()
        {

        }

        public virtual void Gravity()
        {
            
            
        }

        public void Draw(Graphics dc)
        {

        }

        public void UpdateAnimations(float fps)
        {

        }
    }
}
