using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    class PowerUps
    {
        public bool active;

        //tid i sekunder powerupen er aktiv
        public float duration;

        public Vector2D position;

        public void Update(float fps)
        {

        }

        public Rectangle CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            }
        }

        public virtual void OnCollision(Actors other)
        {
            if (other is Actors)
            {
                //We are colliding with an other actor
            }
        }
    }



}
