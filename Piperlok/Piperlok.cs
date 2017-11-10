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

        //Refrence to Vector2D
        Vector2D position;

        //bool to ensure that Piperlok is grounded or not
        bool grounded = true;

        //Piperlok's constructor
        public Piperlok(string imagePaths, float speed, int health, Vector2D startposition) : base(speed, imagePaths, startposition)
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
            Gravity();

            //Assigns different keys to Piperloks movement
            if (Keyboard.IsKeyDown(Keys.A))
            {
                position.X -= ((1 / fps) * 150);
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                position.X += ((1 / fps) * 150);
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.Space) && grounded || Keyboard.IsKeyDown(Keys.W) && grounded)
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
            Gravity();
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
            netMove = (jumpHeightLeft - gravityPull) * Form1.currentFps;
            jumpHeightLeft =-gravityPull * Form1.currentFps;

            //sætter en terminal velocity
            if(netMove < -2) { netMove = -2; }
            position.Y += netMove * Form1.currentFps;

            
        }

        public override void OnCollision(Actors other)
        {
            if(other is Actors)
            {
                //We are colliding with an other actor
            }
        }

        public override void OnCollision(Objects other)
        {
            throw new NotImplementedException();
        }
    }
}
