using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    class Milo_MacDonald : Actors
    {

        int damage;

<<<<<<< HEAD
<<<<<<< HEAD
        public Milo_MacDonald(string imagePaths, float speed, int health, PointF startPosition) : base(speed, imagePaths, startPosition)
=======
        public Milo_MacDonald(string imagePaths, float speed, int health, Vector2D startPosition) : base(speed, imagePaths, startPosition)
>>>>>>> origin/ReBrachingMikkel
=======
        public Milo_MacDonald(string imagePaths, float speed, int health, Vector2D startPosition) : base(speed, imagePaths, startPosition)
>>>>>>> 23872359dd5181df5f022fc9378fc945d816f658
        {

            name = "Milo MacDonald";

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
