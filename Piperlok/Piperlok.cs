using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Piperlok
{
    class Piperlok : Actors
    {
        float jumpHeight;
        float jumpHeightLeft;
        float jumpTime;

        public RectangleF collisionBox;

        Image piperlokSprite = Image.FromFile(@"C: \Users\Allan\source\repos\Piperlok\Piperlok\Sprites\Piperlok.png");

        bool grounded;

        public Piperlok(float speed, int health, PointF startPosition)
        {
            name = "Piperlok";
            //skab en sprite og collision box til piperlok
           // Graphics sprite = Graphics.FromImage(piperlokSprite);
            collisionBox.Height = piperlokSprite.Height;
            collisionBox.Width = piperlokSprite.Width;

            //sætter piperlok i midten af skærmen
            position.X = 1200 / 2;
            position.Y = 900 / 2;
        }

        public override void Update(float fps)
        {
            //Checks if the spacebar is down and if Piperlok is on the ground then Piperlok will jump
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.Space) && grounded)
            {
                Jump();
            }
            //
            if (Keyboard.IsKeyDown(Keys.E)) { }
        }

        public override void Movement()
        {
            if (Keyboard.IsKeyDown(Keys.A))
            {
                position.X -= speed / Form1.currentFps;
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                position.X += speed / Form1.currentFps;
            }
            
            if (Keyboard.IsKeyDown(Keys.W))
            {
                Jump();
            }
            //Duck
            /*if (Keyboard.IsKeyDown(Keys.S))
            {

            }*/
        }
        public void Interact()
        {

        }
        public void Jump()
        {
            grounded = false;
            jumpHeightLeft = jumpHeight;
        }

        public override void Collide()
        {
            base.Collide();
        }

        //bruges til at interagere med nogle objekter, starter minigames
        public void Hack()
        {

        }

        //flytter på objekter som er defineret som moveable
        public void PushPull()
        {

        }

        public override void Gravity()
        {
            base.Gravity();

            //udregner hoppet som en fysisk bevægelse, hoppet bliver langsommere
            float netMove;
            netMove = jumpHeightLeft - gravityPull * Form1.currentFps;
            jumpHeightLeft =-gravityPull * Form1.currentFps;

            //sætter en terminal velocity
            if(netMove < -2) { netMove = -2; }
            position.Y += netMove * Form1.currentFps;

            
        }
    }
}
