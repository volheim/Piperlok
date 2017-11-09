using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    class Vector2D
    {

        float x;
        float y;


        public Vector2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public float Y
        {
            get { return this.y; }
            set { this.y = value; }
        }


    }
}
