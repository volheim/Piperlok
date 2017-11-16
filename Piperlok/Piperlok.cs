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

        GameWorld gw;

        float jumpHeight = 30;
        float jumpHeightLeft;
        float jumpTime;

        public static bool invincible;

        public static bool nextLevel;
        public static bool prevLevel;

        // used when player fall out off map
        private Vector2D startPosition;
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
        public Piperlok(string imagePaths, float speed, int health, Vector2D startposition, float scaleFactor, string name) : base(imagePaths, speed, startposition, scaleFactor, name)
        {
            
            this.health = health;
            gw = this.gw;

            name = "Piperlok";
            //skab en sprite og collision box til piperlok
            position = startposition;
            position.Y = startposition.Y - (this.sprite.Height * scaleFactor);

            grounded = false;
            this.startPosition = position;
        }

        //Piperloks Update funktion
        public override void Update(float fps)
        {
            if(CollisionBox.Right >= 1199 && GameWorld.curentLevel < 3)
            {
                nextLevel = true;
            }
            /*if (CollisionBox.Left <= 1 && GameWorld.curentLevel > 1)
            {
                prevLevel = true;
            }*/

            IsAlive();
            //Calls Gravity
            if (!grounded)
            {
                Gravity();
            }
            else
            {
                jumpHeightLeft = 0;
            }
            //Assigns different keys to Piperloks movement
            if (Keyboard.IsKeyDown(Keys.A) || Keyboard.IsKeyDown(Keys.Left))
            {
                position.X -= ((1 / fps) * 150);
            }
            if (Keyboard.IsKeyDown(Keys.D)|| Keyboard.IsKeyDown(Keys.Right))
            {
                position.X += ((1 / fps) * 150);
            }
            if (Keyboard.IsKeyDown(Keys.Space) && grounded || Keyboard.IsKeyDown(Keys.W) && grounded)
            {
                Jump();
            }

            base.Update(fps);


        }
        public void IsAlive()
        {
            /*if(position.Y + sprite.Height > 1100)
            {
                health--;
                position = startPosition;
                jumpHeightLeft = 0;
                grounded = true;
            }*/
            if(health <= 0)
            {
                GameWorld.curentLevel = 0;
                nextLevel = true;
            }
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

            /*netMove = (jumpHeightLeft - gravityPull) * Form1.currentFps;
            jumpHeightLeft = -gravityPull * Form1.currentFps;

            //sætter en terminal velocity
            if (netMove < -2) { netMove = -2; }
            position.Y += netMove * Form1.currentFps;


        }*/

            netMove = (jumpHeightLeft - (gravityPull * Form1.currentFps / 15));
            jumpHeightLeft -= gravityPull * Form1.currentFps / 15;

            //sætter en terminal velocity
            if (netMove < -9.82f) { netMove = -9.82f; }
            position.Y -= netMove * (Form1.currentFps / 15);


        }
        public override void Draw(Graphics dc)
        {
            Font f = new Font("Arial", 16);
            dc.DrawString(string.Format("JumpheightLeft: {0}", jumpHeightLeft), f, Brushes.Red, 100, 2);
            base.Draw(dc);
        }

        public override void OnCollision(Actors other)
        {

        }

        protected override void CheckCollision()
        {
            grounded = false;
            //Runs through all objects in the GameWorld
            foreach (Objects go in GameWorld.objList)
            {
                //If this object is colliding with the other object
                //Then we have a collision
            if (this.IsCollidingWith(go))
                {
                //a collision has happend
                OnCollision(go);
                }
            }
        }
        public override void IsnotGrounded()
        {
            ///<summary>
            ///this method is called when piperlok did not collide with any object
            ///so by the asumption piperlok is not on the ground
            /// </summary>
            grounded = false;
        }
        public override void OnCollision(Objects other)
        {
            if (other is Lever || other is Computer)
            {
                GameWorld.OpenDoor();
            }

            if(other is Sodavandsautomat)
            {
                foreach (Actors act in GameWorld.actorList)
                {
                    if ( act is TechZombie)
                    {
                        act.health = 0;
                    }
                }
            }
            ///<summary>
            ///piperlok overide funktion til onCollision. den omhandler primært clipping og tyngdekraft så piperlok ikke falder igemmem objekter
            /// </summary>
            if(other is Block)
            {
                ///<summary>
                ///if the object piperlok had a collision  with is of the class WalkableTerrain then this metode will find out where the collision happend. 
                /// </summary> 

                //
                if (this.CollisionBox.Bottom + 2 >= other.CollisionBox.Top && this.CollisionBox.Bottom <= other.CollisionBox.Top + 30 && !grounded)
                {
                    //sætter piperlok til at være oven på et objekt 
                    grounded = true;
                    jumpHeightLeft = 0;
                    position.Y = other.CollisionBox.Top - CollisionBox.Height;
                }

                if (grounded && position.Y + sprite.Height < other.CollisionBox.Top)
                {
                    position.Y = other.CollisionBox.Top - CollisionBox.Height;
                }

                else if (CollisionBox.Right >= other.CollisionBox.Left && CollisionBox.Right <= other.CollisionBox.Left + 20)
                {
                    position.X = other.CollisionBox.Left - CollisionBox.Width;
                }

                else if (CollisionBox.Left >= other.CollisionBox.Right - 20 && CollisionBox.Left <= other.CollisionBox.Right)
                {
                    position.X = other.CollisionBox.Right;
                }
            }

            if (other is PowerUps && health < 3)
            {
                GameWorld.RomovedList.Add(other);
                health++;

            }
        }
    }
}
