using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piperlok
{
    class WalkableTerrain : Objects
    {
        #region Fields
        private Vector2D position;
        private string name;
        #endregion
        #region Properties
        public Vector2D Positions
        {
            get { return position; }
            set { position = value; }
        }

        #endregion
        public WalkableTerrain(bool moveable, bool collideable, string imagePath, Vector2D position, string name, float scalefactor) : base(moveable, collideable, imagePath, position, name, scalefactor)
        {
            this.position = position;
            this.name = name;
        }
    }
}
