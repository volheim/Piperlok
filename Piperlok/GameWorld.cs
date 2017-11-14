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
        LevelReader lr = new LevelReader();

        int[,] level1 = new int[20,15];

        DateTime endTime;

        float currentFps;

        Graphics dc;

        static public List<Objects> objList;
        static public List<PowerUps> powerupList;
        private static List<Actors> actorList;
        private static List<Actors> romovedList;
        BufferedGraphics backBuffer;

        void SetupWorld()
        {
            lr.GenLevel1();
            GenerateLevel();
            endTime = DateTime.Now;
            actorList = new List<Actors>();
            objList = new List<Objects>();
            powerupList = new List<PowerUps>();

            actorList.Add(new Piperlok(@"Sprites\Piperlok.png", 15, 3, new Vector2D(1.5f, 3.0f)));
            //powerupList.Add(new ElefantØl(1,new Vector2D(1.5f, 5f),@"Sprites\elefantøl.png","Beers"));
            //powerupList.Add(new Cola(new Vector2D(1.5f, 10f), @"Sprites\Cola.png"));
            //objList.Add(new Computer(new Vector2D(1.5f, 20f), @"Sprites\computer.png"));
            //objList.Add(new Sodavandsautomat(new Vector2D(1.5f, 30f), @"Sprites\rocket.png"));
        
            romovedList = new List<Actors>();

            actorList.Add(new Piperlok(@"Sprites\Piperlok animation\walk_00.png;Sprites\Piperlok animation\walk_01.png;Sprites\Piperlok animation\walk_02.png;Sprites\Piperlok animation\walk_03.png;Sprites\Piperlok animation\walk_04.png;Sprites\Piperlok animation\walk_05.png;Sprites\Piperlok animation\walk_06.png;Sprites\Piperlok animation\walk_07.png", 15, 3, new Vector2D(1.5f, 520f)));
            actorList.Add(new Camera(@"Sprites\objekter\cameraMrød.png", 10, 100, new Vector2D(400f, 500f)));

        }

        public void GenerateLevel()
        {
            for (int x = 0; x <= 19;)
            {
                for (int y = 0; y <= 14;)
                {
                    level1[x, y] = lr.screen1[x, y];
                    if (level1[x, y] == 0)
                    {

                        //empty
                    }
                    else if (level1[x, y] == 1)
                    {
                        //block
                    }
                    else if (level1[x, y] == 2)
                    {
                        //door
                    }
                    else if (level1[x, y] == 3)
                    {
                        //tech zombie
                        actorList.Add(new TechZombie(@"Sprites\objekter\camerastang.png", 1, 1, new Vector2D(x * 60, y * 60)));
                    }
                    else if (level1[x, y] == 4)
                    {
                        //camera
                        actorList.Add(new Camera(@"Sprites\objekter\cameraMrød.png", 0, 1, new Vector2D(x * 60, y * 60)));
                    }
                    else if (level1[x, y] == 5)
                    {
                        //cola machine

                    }
                    else if (level1[x, y] == 6)
                    {
                        //computer
                        objList.Add(new Computer(new Vector2D(x * 60, y * 60), @"Sprites\objekter\computer.png", "computer"));
                    }
                    else if (level1[x, y] == 7)
                    {
                        //switch

                    }
                    else if (level1[x, y] == 8)
                    {
                        //beer
                        objList.Add(new ElefantØl(1, new Vector2D(x * 60, y * 60), @"Sprites\objekter\elefantøl.png", "beer"));
                    }
                    else if (level1[x, y] == 9)
                    {
                        //power box
                    }
                    y++;
                }
                x++;
            }
        }

        public static List<Actors> ActorList
        {
            get { return actorList; }
            set { actorList = value; }
        }

        public static List<Actors> RomovedList
        {
            get { return romovedList; }
            set { romovedList = value; }
        }

        public void Update(float fps)
        {
            if (romovedList != null)
            {
                foreach (Actors ac in romovedList)
                {
                    actorList.Remove(ac);
                }
            }
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
