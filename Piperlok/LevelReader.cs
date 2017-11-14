﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    public class LevelReader
    {
        Bitmap level1 = new Bitmap(@"Sprites\Levels\Screen1.bmp");
        Bitmap level2 = new Bitmap(@"Sprites\Levels\Screen2.bmp");
        Bitmap level3 = new Bitmap(@"Sprites\Levels\Screen3.bmp");

        public int[,] screen1 = new int[20, 15];
        public int[,] screen2 = new int[20, 15];
        public int[,] screen3 = new int[20, 15];

        /*in levelgen read the bitmaps and save what is where
         * 1 = block
         * 2 = door
         * 3 = tech zombie
         * 4 = camera
         * 5 = cola machine
         * 6 = computer
         * 7 = switch
         * 8 = beer
         * 9 = power box
         */

        public void GenLevel1()
        {
            for (int x = 0; x <= 19; )
            {
                for (int y = 0; y <= 14;)
                {
                    if (level1.GetPixel(x, y).A == 0)
                    {
                        screen1[x, y] = 0;
                    }
                    else if (level1.GetPixel(x,y) == Color.White)
                    {
                        screen1[x, y] = 1;
                    }
                    else if (level1.GetPixel(x, y) == Color.FromArgb(127,121,121))
                    {
                        screen1[x, y] = 2;
                    }
                    else if (level1.GetPixel(x, y) == Color.FromArgb(255,0,0))
                    {
                        screen1[x, y] = 3;
                    }
                    /*else if (level1.GetPixel(x, y) == Color.FromArgb(123,0,0))
                    {
                        screen1[x, y] = 4;
                    }*/
                    else if (level1.GetPixel(x, y) == Color.FromArgb(0, 255, 19))
                    {
                        screen1[x, y] = 5;
                    }
                    /*else if (level1.GetPixel(x, y) == Color.FromArgb(5, 107, 20))
                    {
                        screen1[x, y] = 6;
                    }*/
                    else if (level1.GetPixel(x, y) == Color.FromArgb(145, 255, 153))
                    {
                        screen1[x, y] = 7;
                    }
                    /*else if (level1.GetPixel(x, y) == Color.FromArgb(0, 194, 255))
                    {
                        screen1[x, y] = 8;
                    }
                    else if (level1.GetPixel(x, y) == Color.FromArgb(252, 255, 0))
                    {
                        screen1[x, y] = 9;
                    }*/
                }
            }
        }
        public void GenLevel2()
        {
            foreach (int x in screen2)
            {
                foreach (int y in screen2)
                {
                    if (level2.GetPixel(x, y).A == 0)
                    {
                        screen2[x, y] = 0;
                    }
                    else if (level2.GetPixel(x, y) == Color.White)
                    {
                        screen2[x, y] = 1;
                    }
                    else if (level2.GetPixel(x, y) == Color.FromArgb(127, 121, 121))
                    {
                        screen2[x, y] = 2;
                    }
                    else if (level2.GetPixel(x, y) == Color.FromArgb(255, 0, 0))
                    {
                        screen2[x, y] = 3;
                    }
                    else if (level2.GetPixel(x, y) == Color.FromArgb(123,0,0))
                    {
                        screen2[x, y] = 4;
                    }
                    else if (level2.GetPixel(x, y) == Color.FromArgb(0, 255, 19))
                    {
                        screen2[x, y] = 5;
                    }
                    /*else if (level2.GetPixel(x, y) == Color.FromArgb(5, 107, 20))
                    {
                        screen2[x, y] = 6;
                    }
                    else if (level2.GetPixel(x, y) == Color.FromArgb(145, 255, 153))
                    {
                        screen2[x, y] = 7;
                    }*/
                    else if (level2.GetPixel(x, y) == Color.FromArgb(0, 194, 255))
                    {
                        screen2[x, y] = 8;
                    }
                    /*else if (level2.GetPixel(x, y) == Color.FromArgb(252, 255, 0))
                    {
                        screen2[x, y] = 9;
                    }*/
                }
            }
        }
        public void GenLevel3()
        {
            foreach (int x in screen3)
            {
                foreach (int y in screen3)
                {
                    if (level3.GetPixel(x, y).A == 0)
                    {
                        screen3[x, y] = 0;
                    }
                    else if (level3.GetPixel(x, y) == Color.White)
                    {
                        screen3[x, y] = 1;
                    }
                    else if (level3.GetPixel(x, y) == Color.FromArgb(127, 121, 121))
                    {
                        screen3[x, y] = 2;
                    }
                    else if (level3.GetPixel(x, y) == Color.FromArgb(255, 0, 0))
                    {
                        screen3[x, y] = 3;
                    }
                    /*else if (level3.GetPixel(x, y) == Color.FromArgb(123,0,0))
                    {
                        screen3[x, y] = 4;
                    }
                    else if (level3.GetPixel(x, y) == Color.FromArgb(0, 255, 19))
                    {
                        screen3[x, y] = 5;
                    }
                    else if (level3.GetPixel(x, y) == Color.FromArgb(5, 107, 20))
                    {
                        screen3[x, y] = 6;
                    }
                    else if (level3.GetPixel(x, y) == Color.FromArgb(145, 255, 153))
                    {
                        screen3[x, y] = 7;
                    }
                    else if (level3.GetPixel(x, y) == Color.FromArgb(0, 194, 255))
                    {
                        screen3[x, y] = 8;
                    }*/
                    else if (level3.GetPixel(x, y) == Color.FromArgb(252, 255, 0))
                    {
                        screen3[x, y] = 9;
                    }
                }
            }
        }
    }
}