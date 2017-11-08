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

        static List<Objects> objList;
        static List<Actors> actorList;
        BufferedGraphics backBuffer;

        void SetupWorld()
        {
            actorList = new List<Actors>();
            actorList.Add(new Piperlok(15, 3, new PointF(10, 850)));
        }

        public void Update(float fps)
        {
            foreach(Actors act in actorList)
            {
                act.Update(Form1.currentFps);
            }
            foreach(Objects obj in objList)
            {
                obj.Update(Form1.currentFps);
            }
            UpdateAnimation(fps);
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
            DateTime startTime = DateTime.Now;
            TimeSpan deltaTime = startTime - endTime;
            int milliseconds = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;
            currentFps = 1000 / milliseconds;
            Update(currentFps);
            Draw();
            endTime = DateTime.Now;
        }

        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);

            this.dc = backBuffer.Graphics;

            SetupWorld();
        }
    }
}
