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

        public float currentFps;

        Graphics dc;

        static public List<Objects> objList;
        static public List<PowerUps> powerupList;
        private static List<Actors> actorList;
        private static List<Objects> romovedList;
        private static List<BackGrounds> bgList;
        BufferedGraphics backBuffer;

        void SetupWorld()
        {

            bgList = new List<BackGrounds>();
            endTime = DateTime.Now;
            actorList = new List<Actors>();
            objList = new List<Objects>();

            romovedList = new List<Objects>();

            //actorList.Add(new Piperlok(@"Sprites\Piperlok animation\walk_00.png;Sprites\Piperlok animation\walk_01.png;Sprites\Piperlok animation\walk_02.png;Sprites\Piperlok animation\walk_03.png;Sprites\Piperlok animation\walk_04.png;Sprites\Piperlok animation\walk_05.png;Sprites\Piperlok animation\walk_06.png;Sprites\Piperlok animation\walk_07.png", 15, 3, new Vector2D(1.5f, 580f),3f, "Player"));
            //actorList.Add(new Camera(@"Sprites\objekter\cameraMrød.png", 10, 100, new Vector2D(500f, 380f),0.3f, "cam"));

            //objList.Add(new ElefantØl(1, new Vector2D(200f, 600f), @"Sprites\objekter\elefantøl.png", "Beer", 0.08f, true));
            //objList.Add(new Sodavandsautomat(new Vector2D(700f, 400f), @"Sprites\objekter\g4968.png", "SodaMachine", 0.2f, false));
            //objList.Add(new Lever(new Vector2D(350f, 500f), @"Sprites\Objekter\switchoff.png", "LeverOFF", 0.2f, false));
            //objList.Add(new)

            powerupList = new List<PowerUps>();

            //actorList.Add(new Piperlok(@"Sprites\Piperlok.png", 15, 3, new Vector2D(1.5f, 3.0f)));
            //powerupList.Add(new ElefantØl(1,new Vector2D(1.5f, 5f),@"Sprites\elefantøl.png","Beers"));
            //powerupList.Add(new Cola(new Vector2D(1.5f, 10f), @"Sprites\Cola.png"));
            //objList.Add(new Computer(new Vector2D(1.5f, 20f), @"Sprites\computer.png"));
            //objList.Add(new Sodavandsautomat(new Vector2D(1.5f, 30f), @"Sprites\rocket.png"));

            bgList.Add(new BackGrounds(@"Sprites\Backgrounds\Background_0.png;Sprites\Backgrounds\Background_1.png;Sprites\Backgrounds\Background_2.png;Sprites\Backgrounds\Background_4.png;Sprites\Backgrounds\Background_5.png;Sprites\Backgrounds\Background_6.png", new Vector2D(0, 0)));
            bgList.Add(new BackGrounds(@"Sprites\Backgrounds\Background_0.png;Sprites\Backgrounds\Background_1.png;Sprites\Backgrounds\Background_2.png;Sprites\Backgrounds\Background_4.png;Sprites\Backgrounds\Background_5.png;Sprites\Backgrounds\Background_6.png", new Vector2D(600, 0)));


            lr.GenLevel1();
            lr.GenLevel2();
            lr.GenLevel3();
            GenerateLevel();

        }

        public void GenerateLevel()
        {
            for (int x = 0; x <= 19;)
            {
                for (int y = 0; y <= 14;)
                {
                    level1[x, y] = lr.screen3[x, y];
                    if (level1[x, y] == 0)
                    {
                        //empty
                    }
                    else if (level1[x, y] == 1)
                    {
                        //block
                        objList.Add(new Block(false, true, @"Sprites\Platforms\BaseBlock.png", new Vector2D((x) * 60, (y+1) * 60), "Block", 1, false));
                    }
                    else if (level1[x, y] == 2)
                    {
                        //door
                    }
                    else if (level1[x, y] == 3)
                    {
                        //tech zombie
                        actorList.Add(new TechZombie(@"Sprites\ZombieAnim\zombie_00.png", 1, 1, new Vector2D((x) * 60, (y+1) * 60), 5f, "zomb"));
                    }
                    else if (level1[x, y] == 4)
                    {
                        //camera
                        actorList.Add(new Camera(@"Sprites\objekter\cameraMrød.png", 10, 100, new Vector2D((x) * 60, (y+1) * 60), 0.3f, "cam"));
                    }
                    else if (level1[x, y] == 5)
                    {
                        //cola machine
                        objList.Add(new Sodavandsautomat(new Vector2D(x * 60, (y + 1) * 60), @"Sprites\objekter\g4968.png","soda machine", 0.3f, false));
                    }
                    else if (level1[x, y] == 6)
                    {
                        //computer
                        objList.Add(new Computer(new Vector2D((x) * 60, (y+1) * 60), @"Sprites\objekter\computer.png", "computer", 0.3f, false));
                    }
                    else if (level1[x, y] == 7)
                    {
                        //lever
                        objList.Add(new Lever(new Vector2D((x * 60)+25, (y+1) * 60), @"Sprites\Objekter\switchoff.png", "LeverOFF", 0.2f, false));
                    }
                    else if (level1[x, y] == 8)
                    {
                        //beer
                        objList.Add(new ElefantØl(1, new Vector2D((x) * 60, (y+1) * 60), @"Sprites\objekter\elefantøl.png", "Beer", 0.08f, true));
                    }
                    else if (level1[x, y] == 9)
                    {
                        //power box
                    }
                    y+=1;
                }
                x+=1;
            }

        }

        public static List<Actors> ActorList
        {
            get { return actorList; }
            set { actorList = value; }
        }

        public static List<Objects> ObjectList
        {
            get { return objList; }
            set { objList = value; }
        }

        public static List<Objects> RomovedList
        {
            get { return romovedList; }
            set { romovedList = value; }
        }

        public void Update(float fps)
        {
            if (romovedList != null)
            {
                foreach (Objects ac in romovedList)
                {
                    objList.Remove(ac);
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
            foreach (BackGrounds bg in bgList)
            {
                bg.Draw(dc);
            }
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
