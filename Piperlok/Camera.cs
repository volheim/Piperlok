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

        Vector2D position;

        public Camera(string imagePaths, float speed, int health, Vector2D startPosition,float scaleFactor, string name) : base(imagePaths,speed, startPosition,scaleFactor, name)
        {
            position = startPosition;
            position.Y = startPosition.Y - (this.sprite.Height * scaleFactor);
        }

        public override void Update(float fps)
        {

        }
        

        //kører hvis kameraet ser piperlok, laver et angreb
        void SpotPiperlok()
        {

        }

        public override void OnCollision(Actors other)
        {
            throw new NotImplementedException();
        }

        public override void OnCollision(Objects other)
        {
            throw new NotImplementedException();
        }
    }
}
