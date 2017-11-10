using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    class Objects
    {
        #region Fields
        //objektet kan flyttes af spilleren
        protected bool moveable;
        protected bool Collideable;
        protected string name;
        protected Vector2D position;
        protected Image sprite;
        #endregion

        public Objects(Vector2D startposition, string imagePath)
        {
            position = startposition;
        }

        //Property for returning a collision rectangle with the correct size and position
        public RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width, /** scaleFactor,*/ sprite.Height /** scaleFactor*/);
            }
        }
        public Objects(bool moveable, bool power, bool dangerous, Graphics sprite, Vector2D position, string name, float weight)
        {

        }

        public void Update(float fps)
        {

        }

        public void Draw(Graphics dc)
        {

        }

        public virtual void OnCollision(Actors other)
        {
            if (other is Actors)
            {
                //We are colliding with an other actor
            }
        }
    }
}
