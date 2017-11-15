using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    public class LevelReader
    {
        Bitmap level1 = new Bitmap(@"Levels\Screen1.bmp");
        Bitmap level2 = new Bitmap(@"Levels\Screen2.bmp");
        Bitmap level3 = new Bitmap(@"Levels\Screen3.bmp");

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
                    if (level1.GetPixel(x, y).ToArgb() == Color.FromArgb(0,0,0).ToArgb())
                    {
                        screen1[x, y] = 0;
                    }
                    else if (level1.GetPixel(x, y).ToArgb() == Color.FromArgb(255,255,255).ToArgb())
                    {
                        screen1[x, y] = 1;
                    }
                    else if (level1.GetPixel(x, y).ToArgb() == Color.FromArgb(127,121,121).ToArgb())
                    {
                        screen1[x, y] = 2;
                    }
                    else if (level1.GetPixel(x, y).ToArgb() == Color.FromArgb(255,13,0).ToArgb())
                    {
                        screen1[x, y] = 3;
                    }
                    else if (level1.GetPixel(x, y).ToArgb() == Color.FromArgb(123,0,0).ToArgb())
                    {
                        screen1[x, y] = 4;
                    }
                    else if (level1.GetPixel(x, y).ToArgb() == Color.FromArgb(0, 255, 19).ToArgb())
                    {
                        screen1[x, y] = 5;
                    }
                    else if (level1.GetPixel(x, y).ToArgb() == Color.FromArgb(5, 107, 20).ToArgb())
                    {
                        screen1[x, y] = 6;
                    }
                    else if (level1.GetPixel(x, y).ToArgb() == Color.FromArgb(145, 255, 153).ToArgb())
                    {
                        screen1[x, y] = 7;
                    }
                    else if (level1.GetPixel(x, y).ToArgb() == Color.FromArgb(0, 194, 255).ToArgb())
                    {
                        screen1[x, y] = 8;
                    }
                    else if (level1.GetPixel(x, y).ToArgb() == Color.FromArgb(252, 255, 0).ToArgb())
                    {
                        screen1[x, y] = 9;
                    }
                    y+=1;
                }
                x+=1;
            }
        }
        public void GenLevel2()
        {
            for (int x = 0; x <= 19;)
            {
                for (int y = 0; y <= 14;)
                {
                    if (level2.GetPixel(x, y).A == 0)
                    {
                        screen2[x, y] = 0;
                    }
                    else if (level2.GetPixel(x, y) == Color.FromArgb(255,255,255))
                    {
                        screen2[x, y] = 1;
                    }
                    else if (level2.GetPixel(x, y) == Color.FromArgb(127, 121, 121))
                    {
                        screen2[x, y] = 2;
                    }
                    else if (level2.GetPixel(x, y) == Color.FromArgb(255, 13, 0))
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
                    else if (level2.GetPixel(x, y) == Color.FromArgb(5, 107, 20))
                    {
                        screen2[x, y] = 6;
                    }
                    else if (level2.GetPixel(x, y) == Color.FromArgb(145, 255, 153))
                    {
                        screen2[x, y] = 7;
                    }
                    else if (level2.GetPixel(x, y) == Color.FromArgb(0, 194, 255))
                    {
                        screen2[x, y] = 8;
                    }
                    else if (level2.GetPixel(x, y) == Color.FromArgb(252, 255, 0))
                    {
                        screen2[x, y] = 9;
                    }
                    y++;
                }
                x++;
            }
        }
        public void GenLevel3()
        {
            for (int x = 0; x <= 19;)
            {
                for (int y = 0; y <= 14;)
                {
                    if (level3.GetPixel(x, y).A == 0)
                    {
                        screen3[x, y] = 0;
                    }
                    else if (level3.GetPixel(x, y) == Color.FromArgb(255,255,255))
                    {
                        screen3[x, y] = 1;
                    }
                    else if (level3.GetPixel(x, y) == Color.FromArgb(127, 121, 121))
                    {
                        screen3[x, y] = 2;
                    }
                    else if (level3.GetPixel(x, y) == Color.FromArgb(255, 13, 0))
                    {
                        screen3[x, y] = 3;
                    }
                    else if (level3.GetPixel(x, y) == Color.FromArgb(123,0,0))
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
                    }
                    else if (level3.GetPixel(x, y) == Color.FromArgb(252, 255, 0))
                    {
                        screen3[x, y] = 9;
                    }
                    y++;
                }
                x++;
            }
        }

    }
}
