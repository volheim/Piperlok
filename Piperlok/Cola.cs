using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    class Cola : PowerUps
    {
        //bruges når colaen kastes
        public float speed;
        Vector2D position;

        public Cola(Vector2D startposition, string imagePath,string name) : base(startposition,imagePath,name)
        {
            position = startposition;
        }

        //bruges til at udregne colaens bevægelse når den kastes
        struct Vector2
        {

        }

        public override void OnCollision(Actors other)
        {
            if (other is Actors)
            {
                //Piperlok is colliding with a cola
            }
        }
    }
}
