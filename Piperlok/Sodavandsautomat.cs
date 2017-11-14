﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piperlok
{
    class Sodavandsautomat : Objects
    {
        public bool active;
        Vector2D position;

        public Sodavandsautomat(Vector2D startposition, string imagePath, string name, float scaleFactor, bool destroyable) :base (false,false, imagePath,startposition, name, scaleFactor, destroyable)
        {
            position = startposition;
        }

        public override void OnCollision(Actors other)
        {
            if (other is Actors)
            {
                //Piperlok is colliding with a cola
            }
        }
    }
}
