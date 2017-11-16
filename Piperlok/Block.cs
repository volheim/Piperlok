using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    class Block : Objects
    {
        Block thisBlock;
        public bool door;

        public Block(bool moveable, bool collideable, string imagePath, Vector2D position, string name, float scalefactor, bool destroyable) : base(false, true, imagePath, position, name, scalefactor, false)
        {
            this.destroyable = destroyable;
            this.door = door;

            //position.Y = position.Y - (sprite.Height * scalefactor);
        }
    }
}
