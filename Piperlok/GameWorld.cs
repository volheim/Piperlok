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

        Graphics dc;

        static public List<Objects> objList;
        static public List<Actors> actorList;
        static public List<PowerUps> powerupList;
        BufferedGraphics backBuffer;

        void SetupWorld()
        {
            endTime = DateTime.Now;
            actorList = new List<Actors>();
            objList = new List<Objects>();
            powerupList = new List<PowerUps>();

            actorList.Add(new Piperlok(@"Sprites\Piperlok.png", 15, 3, new Vector2D(1.5f, 3.0f)));
            powerupList.Add(new ElefantØl(1, new Vector2D(1.5f, 5f), @"Sprites\elefantøl.png"));
            powerupList.Add(new Cola(new Vector2D(1.5f, 10f), @"Sprites\Cola.png"));
            objList.Add(new Computer(new Vector2D(1.5f, 20f), @"Sprites\computer.png"));
            objList.Add(new Sodavandsautomat(new Vector2D(1.5f, 30f), @"Sprites\rocket.png"));
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
