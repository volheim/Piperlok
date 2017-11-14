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
        private static Rectangle DisplayRectangle;
        static public List<Objects> objList;
        static public List<Actors> actorList;
        BufferedGraphics backBuffer;

        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);

            this.dc = backBuffer.Graphics;
            SetupWorld();
        }

        void SetupWorld()
        {
            endTime = DateTime.Now;
            actorList = new List<Actors>();
            objList = new List<Objects>();


            objList.Add(new WalkableTerrain(false, true, @"Images\Platforms\BaseBlock.png", new Vector2D(1.5f, 570f), "bb1", 1));
            objList.Add(new WalkableTerrain(false, true, @"Images\Platforms\BaseBlock.png", new Vector2D(1.5f, 100f), "bb2", 1));
            objList.Add(new WalkableTerrain(false, true, @"Images\Platforms\BaseBlock.png", new Vector2D(200f, 600f), "bb3", 1));
            actorList.Add(new Piperlok(@"Sprites\Piperlok animation\walk_00.png;Sprites\Piperlok animation\walk_01.png;Sprites\Piperlok animation\walk_02.png;Sprites\Piperlok animation\walk_03.png;Sprites\Piperlok animation\walk_04.png;Sprites\Piperlok animation\walk_05.png;Sprites\Piperlok animation\walk_06.png;Sprites\Piperlok animation\walk_07.png", 15, 3, new Vector2D(1.5f, 520f),2f));
            actorList.Add(new Camera(@"Enemy.png", 10, 100, new Vector2D(400f, 500f),0.1f));
            
        }

        public List<Actors> ActorList
        {
            get { return actorList; }
            set { actorList = value; }
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
            
        }

        public void Draw()
        {
            dc.Clear(Color.Black);        
#if DEBUG
            Font f = new Font("Arial", 16);
            dc.DrawString(string.Format("FPS : {0}", currentFps), f, Brushes.Red, 2,2);
#endif
            foreach (Objects obj in objList)
            {
                obj.Draw(dc);
            }
            foreach (Actors act in actorList)
            {
                act.Draw(dc);
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
    }
}
