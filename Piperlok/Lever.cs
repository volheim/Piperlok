using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piperlok 
{
    class Lever : Objects
    {
        public bool active;
        Vector2D position;

        public Lever(Vector2D startposition, string imagePath, string name, float scaleFactor, bool destroyable) :base (false,false, imagePath,startposition, name, scaleFactor, destroyable)
        {
            position = startposition;
            position.Y = startposition.Y - (this.sprite.Height * scaleFactor);
        }

        public override void OnCollision(Actors other)
        {
            if (other is Actors)
            {
                //Piperlok is colliding with a cola
            }
        }
        public override void Collide()
        {
            base.Collide();
        }
    }
}
