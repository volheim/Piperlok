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
        public static int curentLevel;
        LevelReader lr = new LevelReader();


        int[,] level;

        DateTime endTime;
        DateTime invincibleTime;

        public float currentFps;

        Graphics dc;
        private static Rectangle DisplayRectangle;
        static public List<Objects> objList;
        static public List<PowerUps> powerupList;
        public static List<Actors> actorList;
        private static List<Objects> romovedList;
        private static List<BackGrounds> bgList;
        BufferedGraphics backBuffer;

        public GameWorld(Graphics dc, Rectangle displayRectangle, GameWorld gw)
        {

            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);

            this.dc = backBuffer.Graphics;
            SetupWorld();
        }


        public void SetupWorld()
        {
            
            curentLevel++;
            level = new int[20, 15];
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

        public static void RemoveDoor(Objects b)
        {
            if (b.destroyable)
            {
                romovedList.Add(b);
            }
        }


        public static void OpenDoor()
        {
            foreach (Objects b in ObjectList)
            {
                if (b is Block)
                {
                    RemoveDoor(b);
                }
            }
        }

        public void GenerateLevel()
        {
            //fill boxes jus below screen
            for (int x = 0; x < 1200;)
            {
                int y = 900;
                objList.Add(new Block(false, true, @"Sprites\Platforms\BaseBlock.png", new Vector2D(x,y), "Block", 1, false));
                x += 60;
            }

            for (int y = 0; y < 910;)
            {
                objList.Add(new Block(false, true, @"Sprites\Platforms\BaseBlock.png", new Vector2D(-60, y), "Block", 1, false));
                objList.Add(new Block(false, true, @"Sprites\Platforms\BaseBlock.png", new Vector2D(1200, y), "Block", 1, false));
                y += 60;
            }

            if(curentLevel == 1)
            {
                lr.GenLevel1();
                level = lr.screen1;
            }
            if (curentLevel == 2)
            {
                level = lr.screen2;
                lr.GenLevel2();
            }
            if (curentLevel == 3)
            {
                lr.GenLevel3();
                level = lr.screen3;
            }


            for (int x = 0; x <= 19;)
            {
                for (int y = 0; y <= 14;)
                {
                    if (level[x, y] == 0)
                    {
                        //empty
                    }
                    else if (level[x, y] == 1)
                    {
                        //block
                        objList.Add(new Block(false, true, @"Sprites\Platforms\BaseBlock.png", new Vector2D((x) * 60, (y) * 60), "Block", 1, false));
                    }
                    else if (level[x, y] == 2)
                    {
                        //door
                        objList.Add(new Block(false, true, @"Sprites\Platforms\BaseBlock.png", new Vector2D((x) * 60, (y) * 60), "Block", 1, true));
                    }
                    else if (level[x, y] == 3)
                    {
                        //tech zombie
                        actorList.Add(new TechZombie(@"Sprites\ZombieAnim\zombie_00.png", 1, 1, new Vector2D((x) * 60, (y+1) * 60), 3.5f, "zomb", 1));
                    }
                    else if (level[x, y] == 4)
                    {
                        //camera
                        actorList.Add(new Camera(@"Sprites\objekter\cameraMrød.png", 10, 100, new Vector2D((x) * 60, (y+1) * 60), 0.3f, "cam"));
                    }
                    else if (level[x, y] == 5)
                    {
                        //cola machine
                        objList.Add(new Sodavandsautomat(new Vector2D(x * 60, (y + 1) * 60), @"Sprites\objekter\g4968.png","soda machine", 0.3f, false));
                    }
                    else if (level[x, y] == 6)
                    {
                        //computer
                        objList.Add(new Computer(new Vector2D((x) * 60, (y+1) * 60), @"Sprites\objekter\computer.png", "computer", 0.3f, false));
                    }
                    else if (level[x, y] == 7)
                    {
                        //lever
                        objList.Add(new Lever(new Vector2D((x * 60)+25, (y+1) * 60), @"Sprites\Objekter\switchoff.png", "LeverOFF", 0.2f, false));
                    }
                    else if (level[x, y] == 8)
                    {
                        //beer
                        objList.Add(new ElefantØl(1, new Vector2D((x) * 60, (y+1) * 60), @"Sprites\objekter\elefantøl.png", "Beer", 0.08f, true));
                    }
                    else if (level[x, y] == 9)
                    {
                        //power box
                    }
                    if (level[x, y] == 10)
                    {
                        //piperlok
                        actorList.Add(new Piperlok(@"Sprites\Piperlok animation\walk_00.png;Sprites\Piperlok animation\walk_01.png;Sprites\Piperlok animation\walk_02.png;Sprites\Piperlok animation\walk_03.png;Sprites\Piperlok animation\walk_04.png;Sprites\Piperlok animation\walk_05.png;Sprites\Piperlok animation\walk_06.png;Sprites\Piperlok animation\walk_07.png", 15, 3, new Vector2D(x * 60f, y * 60f), 3.5f, "Player"));
                    }
                    y +=1;
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

            if (Piperlok.nextLevel)
            {
                SetupWorld();
                Piperlok.nextLevel = false;
            }


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


            foreach (BackGrounds bg in bgList)
            {
                bg.Draw(dc);
            }
            foreach (Objects obj in objList)
            {
                obj.Draw(dc);
            }
            foreach (Actors act in actorList)
            {
                act.Draw(dc);
            }

#if DEBUG
            Font f = new Font("Arial", 16);
            dc.DrawString(string.Format("FPS : {0}", currentFps), f, Brushes.Red, 2, 2);
#endif

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
            if (Piperlok.invincible && (invincibleTime.Second +0.5f <= DateTime.Now.Second || (invincibleTime.Second >= 59.5f && DateTime.Now.Second <= 59.4f)))
            {
                Piperlok.invincible = false;
            }
        }
    }
}
