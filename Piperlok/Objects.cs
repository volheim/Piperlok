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
<<<<<<< HEAD

        public Objects(bool moveable, bool collideable, string imagePath, Vector2D position, string name, float scalefactor, bool destroyable)
=======
        public Vector2D Position
        {
            get { return position; }
        }
        #endregion
        public Objects(bool moveable, bool collideable, string imagePath, Vector2D position, string name, float scalefactor)
>>>>>>> origin/Jump
        {
            this.moveable = moveable;
            this.collideable = collideable;
            sprite = Image.FromFile(imagePath);
            this.position = position;
            this.name = name;
            this.scaleFactor = scalefactor;

        }
        public Vector2D Position
        {
            get { return position; }
        }


        #endregion


        //Property for returning a collision rectangle with the correct size and position
        public RectangleF CollisionBox
        {
            get
            {
<<<<<<< HEAD
                return new RectangleF(position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
=======
                return new RectangleF(position.X, position.Y, sprite.Width*scaleFactor, sprite.Height*scaleFactor);
>>>>>>> origin/Jump
            }
        }


        public void Update(float fps)
        {

        }

        public void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            dc.DrawRectangle(new Pen(Brushes.Red), CollisionBox.X, CollisionBox.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            dc.DrawRectangle(new Pen(Brushes.Green), CollisionBox.X, CollisionBox.Y - 2, sprite.Width * scaleFactor, 5 * scaleFactor);
            dc.DrawRectangle(new Pen(Brushes.Green), CollisionBox.X, CollisionBox.Y + CollisionBox.Height - 5, sprite.Width * scaleFactor, 5 * scaleFactor);
            dc.DrawRectangle(new Pen(Brushes.Green), CollisionBox.X, CollisionBox.Y + CollisionBox.Height - 5, sprite.Width * scaleFactor, 5 * scaleFactor);
            dc.DrawRectangle(new Pen(Brushes.Green), CollisionBox.X, CollisionBox.Y+5, 5 * scaleFactor, (sprite.Height - 5) * scaleFactor);
            dc.DrawRectangle(new Pen(Brushes.Green), CollisionBox.X+CollisionBox.Width-5 , CollisionBox.Y +5, 5 * scaleFactor,(sprite.Height-5) * scaleFactor);

        }

        public virtual void OnCollision(Actors other)
        {
            if (other is Piperlok)
            {
<<<<<<< HEAD
                GameWorld.RomovedList.Add(this);
=======

>>>>>>> origin/Jump
            }
        }
        public virtual void Collide()
        {
            
        }

        
    }
}
