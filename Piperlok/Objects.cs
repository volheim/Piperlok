using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    abstract class Objects
    {
        #region Fields
        //objektet kan flyttes af spilleren
        protected bool moveable;
        protected bool collideable;
        protected string name;
        protected Vector2D position;
        protected Image sprite;
        protected float scaleFactor;
        public bool destroyable;
        #endregion
        #region Properties
        public Objects(bool moveable, bool collideable, string imagePath, Vector2D position, string name, float scalefactor, bool destroyable)
        {
            this.moveable = moveable;
            this.collideable = collideable;
            sprite = Image.FromFile(imagePath);
            this.position = position;
            this.name = name;
            this.scaleFactor = scalefactor;

        }
        //property for returning the position of the object
        public Vector2D Position
        {
            get { return position; }
        }
        //Property for returning a collision rectangle with the correct size and position
        public RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            }
        }
        #endregion
        //the objects update method
        public void Update(float fps)
        {

        }

        public void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
#if DEBUG
            //dc.DrawRectangle(new Pen(Brushes.Red), CollisionBox.X, CollisionBox.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
#endif
        }
        //not need in this build
        public virtual void OnCollision(Actors other)
        {
            if (other is Piperlok)
            {
                GameWorld.RomovedList.Add(this);
            }
        }
        //Delete me
        public virtual void Collide()
        {
            
        }
    }
}
