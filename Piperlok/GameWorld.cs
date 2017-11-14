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
        DateTime endTime;

        float currentFps;
        BackGrounds bg;
        Graphics dc;

        static public List<Objects> objList;
        private static List<Actors> actorList;
        private static List<Objects> romovedList;
        BufferedGraphics backBuffer;

        void SetupWorld()
        {
            endTime = DateTime.Now;
            actorList = new List<Actors>();
            objList = new List<Objects>();
            romovedList = new List<Objects>();

            actorList.Add(new Piperlok(@"Sprites\Piperlok animation\walk_00.png;Sprites\Piperlok animation\walk_01.png;Sprites\Piperlok animation\walk_02.png;Sprites\Piperlok animation\walk_03.png;Sprites\Piperlok animation\walk_04.png;Sprites\Piperlok animation\walk_05.png;Sprites\Piperlok animation\walk_06.png;Sprites\Piperlok animation\walk_07.png", 15, 3, new Vector2D(1.5f, 580f),3f, "Player"));
            actorList.Add(new Camera(@"Sprites\objekter\cameraMrød.png", 10, 100, new Vector2D(500f, 380f),0.3f));

            objList.Add(new ElefantØl(1, new Vector2D(200f, 600f), @"Sprites\objekter\elefantøl.png", "Beer", 0.08f, true));
            objList.Add(new Sodavandsautomat(new Vector2D(700f, 400f), @"Sprites\objekter\g4968.png", "SodaMachine", 0.2f, false));
            objList.Add(new Lever(new Vector2D(350f, 500f), @"Sprites\Objekter\switchoff.png", "LeverOFF", 0.2f, false));
            objList.Add(new)
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
