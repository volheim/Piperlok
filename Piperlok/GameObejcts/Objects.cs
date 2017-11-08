using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok.GameObejcts
{
    class Objects
    {
        //objektet kan flyttes af spilleren
        bool moveable;
        //objektet kan aktivere visse andre objekter
        bool power;
        //objekter giver skade på kollision
        bool dangerous;

        Graphics sprite;

        PointF position;

        string name;

        //højere værdi gør det sværre at flytte et objekt
        float weight;

        public Objects (bool moveable, bool power, bool dangerous, Graphics sprite, PointF position, string name, float weight)
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
