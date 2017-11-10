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

<<<<<<< HEAD
        public TechZombie(string imagePaths, float speed, int health, Vector2D startPosition) : base(speed, imagePaths, startPosition)
=======
        public TechZombie(string imagePaths, float speed, int health, PointF startPosition) : base(speed, imagePaths, startPosition)
>>>>>>> origin/Skywalker
        {

        }

        public override void Update(float fps)
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
