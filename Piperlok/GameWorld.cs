using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Piperlok
{
    class GameWorld
    {
        int curentLevel;

        DateTime endTime;

        float currentFps;

        Graphics dc;

        static public List<Objects> objList;
        static public List<Actors> actorList;
        static public List<PowerUps> powerupList;
        BufferedGraphics backBuffer;


        public int[,] level1 = new int[20, 15];
        public int[,] level2 = new int[20, 15];
        public int[,] level3 = new int[20, 15];

        void SetupWorld()
        {
            curentLevel = 1;

            LevelReader levelReader = new LevelReader();
            levelReader.GenLevel1();
            levelReader.GenLevel2();
            levelReader.GenLevel3();

            level1 = levelReader.screen1;
            level2 = levelReader.screen2;
            level3 = levelReader.screen3;

            endTime = DateTime.Now;
            actorList = new List<Actors>();
            objList = new List<Objects>();
            powerupList = new List<PowerUps>();

            actorList.Add(new Piperlok(@"Sprites\Piperlok.png", 15, 3, new Vector2D(14*60, 1*60)));
            //powerupList.Add(new ElefantØl(1,new Vector2D(1.5f, 5f),@"Sprites\elefantøl.png","Beers",2));
            
            
            //powerupList.Add(new Cola(new Vector2D(1.5f, 10f), @"Sprites\Cola.png", "cola", curentLevel));
            //objList.Add(new Computer(new Vector2D(1.5f, 20f), @"Sprites\computer.png"));
            objList.Add(new Sodavandsautomat(new Vector2D(1.5f, 30f), @"Sprites\rocket.png", "cola machine", curentLevel));

            //generate levels from LevelReader class



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
            for (int x = 0; x <= 19;)
            {
                for (int y = 0; y <= 14;)
                {
                    if (level1[x, y] == 0)
                    {
                        //place nothing
                    }
                    else if (level1[x, y] == 1)
                    {
                        //make a block
                    }
                    else if (level1[x, y] == 2)
                    {
                        //make a door
                    }
                    else if (level1[x, y] == 3)
                    {
                        //add zombie
                        actorList.Add(new TechZombie(@"image path", 5, 1, new Vector2D(x * 60, y * 60)));
                    }
                    else if (level1[x, y] == 4)
                    {
                        //add camera
                        actorList.Add(new Camera(@"image path", 0, 1, new Vector2D(x * 60, y * 60)));
                    }
                    else if (level1[x, y] == 5)
                    {
                        //add sodamachine
                        objList.Add(new Sodavandsautomat(new Vector2D(x*60, y*60), @"Sprites\objekter\g4968.png", "cola machine", curentLevel));
                    }
                    else if (level1[x, y] == 6)
                    {
                        //add computer
                        objList.Add(new Computer(new Vector2D(x * 60, y * 60), @"Sprites\objekter\computer.png", "computer", curentLevel));
                    }
                    else if (level1[x, y] == 7)
                    {
                        //make a switch
                    }
                    else if (level1[x, y] == 8)
                    {
                        //add beer
                        powerupList.Add(new ElefantØl(1, new Vector2D(x * 60, y * 60), @"Sprites\elefantøl.png", "Beers", curentLevel));
                    }
                    else if (level1[x, y] == 9)
                    {
                        //make a power box
                    }
                }
            }
            
        }

        public void Update(float fps)
        {
            foreach(Actors act in actorList)
            {
                act.Update(Form1.currentFps);
            }
            UpdateAnimation(fps);
            foreach (Objects obj in objList)
            {
                obj.Update(Form1.currentFps);
            }
            foreach (PowerUps pow in powerupList)
            {
                pow.Update(Form1.currentFps);
            }
            
        }

        public void Draw()
        {
            dc.Clear(Color.Black);

#if DEBUG
            Font f = new Font("Arial", 16);
            dc.DrawString(string.Format("FPS : {0}", currentFps), f, Brushes.Red, 2,2);
#endif 
            foreach (Actors act in actorList)
            {
                act.Draw(dc);
            }
            foreach (Objects obj in objList)
            {
                obj.Draw(dc);
            }
            backBuffer.Render();
        }

        void UpdateAnimation(float fps)
        {
            foreach (Actors act in actorList)
            {
                act.UpdateAnimations(fps);
            }
        }

        public void GameLoop()
        {
            DateTime startTime = DateTime.Now; //Log start time
            TimeSpan deltaTime = startTime - endTime; //Time it took since last loop
            int milliseconds = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1; //Get milliseconds since last gameloop from the deltatime
            currentFps = 1000 / milliseconds; //Calculates current fps
            Update(currentFps);// Updates the game
            Draw(); //Draws the game
            endTime = DateTime.Now; //Log end time
        }

        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);

            this.dc = backBuffer.Graphics;

            SetupWorld();
        }
    }
}
