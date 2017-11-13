using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piperlok.Interfaces;

namespace Piperlok.GameObejcts
{
    class Box : Object, IMoveable, IGravity
    {
        public void Gravity()
        {
            throw new NotImplementedException();
        }
        public Box(Vector2D startposition, string imagePath, string name, int level)
        {

        }
    }
}
