﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    class Camera : Actors
    {
        int damage;

        //et skud fra kameraet
        Object bullet;

<<<<<<< HEAD
        public Camera(string imagePaths, float speed, int health, Vector2D startPosition) : base(speed, imagePaths, startPosition)
=======
        public Camera(string imagePaths, float speed, int health, PointF startPosition) : base(speed, imagePaths, startPosition)
>>>>>>> origin/Skywalker
        {

        }

        public override void Update(float fps)
        {

        }
        

        //kører hvis kameraet ser piperlok, laver et angreb
        void SpotPiperlok()
        {

        }

        public override void Collide()
        {
            base.Collide();
        }
    }
}
