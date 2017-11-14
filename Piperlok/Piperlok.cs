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
        float jumpHeight = 30;
        float jumpHeightLeft;
        float jumpTime;


        //Refrence to Vector2D
        private Vector2D position;
        //bool to ensure that Piperlok is grounded or not
        bool grounded = true;
        public bool Grounded { get { return grounded; } set { grounded = value; } }
        public RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            }
            set { CollisionBox = value; }
        }
        //Piperlok's constructor
        public Piperlok(string imagePaths, float speed, int health, Vector2D startposition, float scaleFactor) : base(imagePaths, speed, startposition, scaleFactor)
        {
            name = "Piperlok";
            //skab en sprite og collision box til piperlok
            position = startposition;

            bool grounded = true;
        }

        //Piperloks Update funktion
        public override void Update(float fps)
        {
            //Calls Gravity
            if (!grounded)
            {
                Gravity();
            }
            //Assigns different keys to Piperloks movement
            if (Keyboard.IsKeyDown(Keys.A))
            {
                position.X -= ((1 / fps) * 150);
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                position.X += ((1 / fps) * 150);
            }
            if (Keyboard.IsKeyDown(Keys.Space) && grounded || Keyboard.IsKeyDown(Keys.W) && grounded)
            {
                Jump();
            }

            base.Update(fps);
        }

        //Piperloks Jump funktion
        public void Jump()
        {
            grounded = false;
            jumpHeightLeft = jumpHeight;
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
            netMove = (jumpHeightLeft - (gravityPull * Form1.currentFps / 10));
            jumpHeightLeft -= gravityPull * Form1.currentFps / 10;

            //sætter en terminal velocity
            if (netMove < -3) { netMove = -3; }
            position.Y -= netMove * (Form1.currentFps / 10);



        }
        public override void Draw(Graphics dc)
        {
            Font f = new Font("Arial", 16);
            dc.DrawString(string.Format("JumpheightLeft: {0}", jumpHeightLeft), f, Brushes.Red, 100, 2);
            base.Draw(dc);
        }
        public override void OnCollision(Actors other)
        {
            foreach (Piperlok go in GameWorld.actorList)
            {
                //If the Actors we are checking isn't itself
                //This prevents them from colliding with itself
                if (go != this)
                {
                    //If this object is colliding with the other object
                    //Then we have a collision
                }
            }
        }
        public override void IsnotGrounded()
        {
            grounded = false;
            base.IsnotGrounded();
        }
        public override void OnCollision(Objects other)
        {


            if (this.CollisionBox.Bottom + 2 >= other.CollisionBox.Top && this.CollisionBox.Bottom <= other.CollisionBox.Top + 20 && !grounded)
            {
                //sætter piperlok til at være oven på kassen
                grounded = true;
                jumpHeightLeft = 0;
                position.Y = other.CollisionBox.Top - CollisionBox.Height;

            }

            else if (CollisionBox.Right >= other.CollisionBox.Left && CollisionBox.Right <= other.CollisionBox.Left + 10 && !grounded)
            {
                position.X = other.CollisionBox.Left - CollisionBox.Width;
            }
            else if (CollisionBox.Left >= other.CollisionBox.Right && CollisionBox.Left <= other.CollisionBox.Right - 10 && !grounded)
            {
                position.X = other.CollisionBox.Right;
            }

            //Grounded
            if (grounded && position.Y + sprite.Height < other.CollisionBox.Top)
            {
                position.Y = other.CollisionBox.Top - CollisionBox.Height;
            }
            else if (CollisionBox.Right >= other.CollisionBox.Left && grounded)
            {
                position.X = other.CollisionBox.Left - CollisionBox.Width;
            }
            else if (CollisionBox.Left <= other.CollisionBox.Right && grounded)
            {
                position.X = other.CollisionBox.Right;
            }

        }
    }
}
