using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    class Camera : Actors
    {
        int damage;

        //et skud fra kameraet
        Object bullet;

        public Camera(float speed, PointF startPosition, Graphics sprite, int damage)
        {

        }

        public override void Update(float fps)
        {

        }

        public override void Movement()
        {

        }

        //kører hvis kameraet ser piperlok, laver et angreb
        void SpotPiperlok()
        {

        }

        public override void Collide()
        {
            base.Collide();
        }
    }
}
