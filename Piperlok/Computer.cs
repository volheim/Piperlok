using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piperlok
{
    class Computer : Objects
    {
        public bool active;
        Vector2D position;

        public Computer(Vector2D startposition, string imagePath,string name, int level) : base(false, false, imagePath, startposition, name, level)
        {
            position = startposition;
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
