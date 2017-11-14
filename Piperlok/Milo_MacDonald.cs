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

        public Milo_MacDonald(string imagePaths, float speed, int health, Vector2D startPosition, float scaleFactor,  string name) : base(imagePaths,speed , startPosition, scaleFactor, name)
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

        public override void OnCollision(Actors other)
        {
            throw new NotImplementedException();
        }

        public override void OnCollision(Objects other)
        {
            throw new NotImplementedException();
        }
    }
}
