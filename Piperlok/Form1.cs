using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piperlok
{
    public partial class Form1 : Form
    {
        public DateTime endTime;
        DateTime updateStart;
        DateTime updateEnd;
        Graphics dc;

        //Defines the GameWorld
        GameWorld gw;

        public static float currentFps;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Tick1(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;
            TimeSpan deltaTime = startTime - endTime;

            int milliseconds = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;

            currentFps = 1000 / milliseconds;

            endTime = DateTime.Now;

            //Kalder vores GameLoop
            gw.GameLoop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(dc == null)
            {
                dc = CreateGraphics();
            }
            
            //Instantiates the GameWorld
            Rectangle s = this.DisplayRectangle;
            gw = new GameWorld(CreateGraphics(), this.DisplayRectangle);
        }
    }
}
