﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    class PowerUps : Objects
    {
        public bool active;

        //tid i sekunder powerupen er aktiv
        public float duration;

        public Vector2D position;

        public PowerUps(Vector2D startposition, string imagePath, string name) : base(false,true, imagePath, startposition, name)
        {
        }

        public void Update(float fps)
        {

        }
    }



}
