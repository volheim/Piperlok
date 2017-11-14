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
        Vector2D position;

        int damage;

        public TechZombie(string imagePaths, float speed, int health, Vector2D startPosition, float scaleFactor, string name) : base(imagePaths,speed, startPosition, scaleFactor, name)
        {
            position = startPosition;
            position.Y = startPosition.Y - (this.sprite.Height * scaleFactor);
        }

        public override void Update(float fps)
        {
            base.Update(fps);
        }

        

        public override void Collide()
        {
            base.Collide();
        }

        public override void Gravity()
        {
            base.Gravity();
        }

        public override void OnCollision(Actors other)
        {
            if(other is Actors)
            {
                //The "enemy" is colliding with Piperlok
            }
        }

        public override void OnCollision(Objects other)
        {
            //throw new NotImplementedException();
        }
    }
}
