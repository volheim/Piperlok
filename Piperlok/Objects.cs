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
        bool moveable;
        bool Collideable;
        Graphics sprite;
        string name;
        
        Vector2D position;
        #endregion

        //Property for returning a collision rectangle with the correct size and position
        public Rectangle CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            }
        }
        public Objects (bool moveable, bool power, bool dangerous, Graphics sprite, Vector2D position, string name, float weight)
        {

        }

        public void Update(float fps)
        {

        }

        public void Draw(Graphics dc)
        {

        }
    }
}
