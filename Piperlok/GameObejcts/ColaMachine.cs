﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piperlok.Interfaces;
using Piperlok.FPowerUps;

namespace Piperlok.GameObejcts
{
    class ColaMachine : Objects , Ipower
    {
        private int ColasSpawned;
        public ColaMachine(bool moveable, bool power, bool dangerous, Graphics sprite, PointF position, string name, float weight) : base(moveable, power, dangerous, sprite, position, name, weight)
        {
        }

        public void PowerOn()
        {
            throw new NotImplementedException();
        }
        public void SpawnCola()
        {
            if(ColasSpawned <= 0)
            {
                //new Cola(new PointF(10,10)a);
            }
        }
    }
}
