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
        bool destroyable;



        public ElefantØl(int healVal, Vector2D startposition, string imagePath,string name, float scaleFactor, bool destroyable) : base(startposition, imagePath,name, scaleFactor, destroyable)
        {
            position = startposition;
            destroyable = true;
            position.Y = startposition.Y - (this.sprite.Height * scaleFactor);
        }

        public override void OnCollision(Actors other)
        {
            if (other is Actors)
            {
                //PiperLok is colliding with an elephant beer
            }
        }

        public override void Collide()
        {
            base.Collide();
        }
    }
}
