using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    class ElefantØl : PowerUps
    {
        //mængden af liv som heales
        public int healVal;
        Vector2D position;

        public ElefantØl(int healVal, Vector2D startposition, string imagePath) : base(startposition, imagePath)
        {
            position = startposition;
        }

        public override void OnCollision(Actors other)
        {
            if (other is Actors)
            {
                //PiperLok is colliding with an elephant beer
            }
        }
    }

}
