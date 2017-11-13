﻿using System;
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
        protected bool collideable;
        protected string name;
        protected Vector2D position;
        protected Image sprite;
        #endregion

        public Objects(bool moveable, bool collideable, string imagePath, Vector2D position, string name)
        {
            this.moveable = moveable;
            this.collideable = collideable;
            sprite = Image.FromFile(imagePath);
            this.position = position;
            this.name = name;
        }
        //Property for returning a collision rectangle with the correct size and position
        public RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width, /** scaleFactor,*/ sprite.Height /** scaleFactor*/);
            }
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
